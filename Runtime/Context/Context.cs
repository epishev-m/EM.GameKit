namespace EM.GameKit
{

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

	protected EcsContainer EcsContainer;

	#region MonoBehaviour

	private void Awake()
	{
		if (SetGlobalContext())
		{
			CreateDiContainer();
		}

		CreateEcsContainer();
		Initialize();
	}

	private void Start()
	{
		EcsContainer.Run();
		RunAsync(_cts.Token).Forget();
	}

	private void Update()
	{
		if (this != _globalContext)
		{
			return;
		}

		EcsContainer.Update();
	}

	private void OnDestroy()
	{
		if (_globalContext == this)
		{
			return;
		}

		EcsContainer.Destroy();
		_cts.Cancel();
		Release();
		_diContainer.Unbind(LifeTime.Local);
	}

	#endregion

	#region Context

	public static bool IsExistedGlobalContext => _globalContext != null;

	public bool IsGlobalContext => _globalContext == this;

	public IDiContainer DiContainer => _diContainer;

	protected abstract void Initialize();

	protected abstract void Release();

	protected abstract UniTask RunAsync(CancellationToken ct);

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

	private void CreateEcsContainer()
	{
		EcsContainer = new EcsContainer(_diContainer);
	}

	#endregion
}

}