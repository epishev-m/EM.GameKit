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
	private static readonly CancellationTokenSource GlobalContextCts = new();

	private static Context _globalContext;

	private static IDiContainer _diContainer;

	private readonly CancellationTokenSource _cts = new();

	#region MonoBehaviour

	private void Awake()
	{
		if (SetGlobalContext())
		{
			CreateDiContainer();
		}

		Initialize();
	}

	private void Start()
	{
		if (IsGlobalContext)
		{
			RunGlobalContextAsync().Forget();
		}
		else
		{
			RunLocalContextAsync().Forget();
		}
	}

	private void OnDestroy()
	{
		if (_globalContext == this)
		{
			return;
		}

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

	private async UniTask RunGlobalContextAsync()
	{
		await RunAsync(_cts.Token);
		GlobalContextCts.Cancel();
	}

	private async UniTask RunLocalContextAsync()
	{
		await GlobalContextCts.Token.WaitUntilCanceled();
		await RunAsync(_cts.Token);
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
}

}