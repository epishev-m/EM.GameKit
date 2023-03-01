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

	protected static IDiContainer DiContainer;

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
		DiContainer.Unbind(LifeTime.Local);
	}

	#endregion

	#region Context

	public static bool IsExistedGlobalContext => _globalContext != null;

	protected virtual void Initialize(Binder binder)
	{
	}

	protected virtual void InitializeEcs(EcsBinder binder)
	{
	}

	protected virtual void Release()
	{
	}

	protected virtual UniTask RunAsync(CancellationToken ct)
	{
		return UniTask.CompletedTask;
	}

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
		DiContainer = new DiContainer(reflector);

		DiContainer.Bind<IReflector>()
			.InGlobal()
			.To(reflector);

		DiContainer.Bind<IDiContainer>()
			.InGlobal()
			.To(DiContainer);
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
			var bindingLifeTime = DiContainer.Bind<T>();
			var diBinding = _globalContext == _context ? bindingLifeTime.InGlobal() : bindingLifeTime.InLocal();
			diBinding.To<T>().ToSingleton();
			var installer = DiContainer.Resolve<T>();
			installer.InstallBindings(DiContainer);

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
			var bindingLifeTime = DiContainer.Bind<T>();
			var diBinding = _globalContext == _context ? bindingLifeTime.InGlobal() : bindingLifeTime.InLocal();
			diBinding.To<T>().ToSingleton();
			var ecsRunner = DiContainer.Resolve<T>();
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