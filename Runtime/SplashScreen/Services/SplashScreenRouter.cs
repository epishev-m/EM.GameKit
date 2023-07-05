namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class SplashScreenRouter
{
	private readonly IPanelSystem _panelSystem;

	#region SplashScreenRouter

	public SplashScreenRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _panelSystem.OpenAsync<SplashScreenPanelView, SplashScreenViewModel>(ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<SplashScreenPanelView>(ct);
	}

	#endregion
}

}