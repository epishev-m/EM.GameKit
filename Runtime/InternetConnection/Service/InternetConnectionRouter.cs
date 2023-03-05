namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public class InternetConnectionRouter
{
	private readonly IUiSystem _uiSystem;

	private bool _isOpened;

	#region InternetConnectionRouter

	public InternetConnectionRouter(IUiSystem uiSystem)
	{
		_uiSystem = uiSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _uiSystem.OpenAsync<InternetConnectionView, InternetConnectionViewModel>(Modes.Modal, ct);
		_isOpened = true;
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _uiSystem.CloseAsync<InternetConnectionView>(ct);
		_isOpened = false;
	}

	public async UniTask WaiteForCloseAsync(CancellationToken ct)
	{
		await UniTask.WaitUntil(() => !_isOpened, cancellationToken: ct);
	}

	#endregion
}

}