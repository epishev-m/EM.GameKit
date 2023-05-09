namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class CheatsRouter
{
	private readonly IUiSystem _uiSystem;

	#region CheatsRouter

	public CheatsRouter(IUiSystem uiSystem)
	{
		_uiSystem = uiSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _uiSystem.OpenAsync<CheatsView, CheatsViewModel>(ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _uiSystem.CloseAsync<CheatsView>(ct);
	}

	#endregion
}

}