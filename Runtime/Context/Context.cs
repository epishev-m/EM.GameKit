namespace EM.GameKit
{

using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;
using IoC;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class Context : MonoBehaviour
{
	private static Context _globalContext;

	private static IDiContainer _diContainer;

	private readonly CancellationTokenSource _cts = new();

	private EcsBinder _ecsBinder;

	#region MonoBehaviour

	private void Awake()
	{
		if (SetGlobalContext())
		{
			CreateDiContainer();
		}

		Binding();
		EcsBinding();
	}

	private void Start()
	{
		_ecsBinder.Run();
		RunAsync(_cts.Token).Forget();
	}

	private void Update()
	{
		if (this != _globalContext)
		{
			return;
		}

		EcsBinder.Update();
	}

	private void OnDestroy()
	{
		if (_globalContext == this)
		{
			return;
		}

		_ecsBinder.Destroy();
		_cts.Cancel();
		Release();
		_diContainer.Unbind(LifeTime.Local);
	}

	#endregion

	#region Context

	public static bool IsExistedGlobalContext => _globalContext != null;

	protected abstract void Initialize(Binder binder);

	protected abstract void InitializeEcs(EcsBinder binder);

	protected abstract void Release();

	protected abstract UniTask RunAsync(CancellationToken ct);

	private void Binding()
	{
		var binder = new Binder(this);
		Initialize(binder);
	}

	private void EcsBinding()
	{
		_ecsBinder = new EcsBinder(this);
		InitializeEcs(_ecsBinder);
	}

	private bool SetGlobalContext()
	{
		if (_globalContext != null)
		{
			return false;
		}

		_globalContext = this;

		return true;
	}

	private static void CreateDiContainer()
	{
		var reflector = new Reflector();
		_diContainer = new DiContainer(reflector);

		_diContainer.Bind<IReflector>()
			.InGlobal()
			.To(reflector);

		_diContainer.Bind<IDiContainer>()
			.InGlobal()
			.To(_diContainer);
	}

	#endregion

	#region Nested

	protected sealed class Binder
	{
		private readonly Context _context;

		#region Binder

		public Binder(Context context)
		{
			_context = context;
		}

		public Binder Add<T>()
			where T : class, IInstaller
		{
			var bindingLifeTime = _diContainer.Bind<T>();
			var diBinding = _globalContext == _context ? bindingLifeTime.InGlobal() : bindingLifeTime.InLocal();
			diBinding.To<T>().ToSingleton();
			var installer = _diContainer.Resolve<T>();
			installer.InstallBindings(_diContainer);

			return this;
		}

		#endregion
	}

	protected sealed class EcsBinder
	{
		private static readonly List<IEcsRunner> EcsRunners = new();

		private readonly List<IEcsRunner> _localEcsRunners = new();

		private readonly Context _context;

		#region EcsController

		public EcsBinder(Context context)
		{
			_context = context;
		}

		public EcsBinder Add<T>()
			where T : class, IEcsRunner
		{
			var bindingLifeTime = _diContainer.Bind<T>();
			var diBinding = _globalContext == _context ? bindingLifeTime.InGlobal() : bindingLifeTime.InLocal();
			diBinding.To<T>().ToSingleton();
			var ecsRunner = _diContainer.Resolve<T>();
			_localEcsRunners.Add(ecsRunner);
			EcsRunners.Add(ecsRunner);

			return this;
		}

		internal void Run()
		{
			foreach (var ecsRunner in _localEcsRunners)
			{
				ecsRunner.Initialize();
			}
		}

		internal static void Update()
		{
			foreach (var ecsRunner in EcsRunners)
			{
				ecsRunner.Update();
			}
		}

		internal void Destroy()
		{
			foreach (var ecsRunner in _localEcsRunners)
			{
				EcsRunners.Remove(ecsRunner);
				ecsRunner.Release();
			}

			_localEcsRunners.Clear();
		}

		#endregion
	}

	#endregion
}

}