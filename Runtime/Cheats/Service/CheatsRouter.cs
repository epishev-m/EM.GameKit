namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class CheatsRouter
{
	private readonly IPanelSystem _panelSystem;

	#region CheatsRouter

	public CheatsRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _panelSystem.OpenAsync<CheatsPanelView, CheatsViewModel>(ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<CheatsPanelView>(ct);
	}

	#endregion
}

}