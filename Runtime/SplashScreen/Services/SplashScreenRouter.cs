namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class SplashScreenRouter
{
	private readonly IUiSystem _uiSystem;

	#region SplashScreenRouter

	public SplashScreenRouter(IUiSystem uiSystem)
	{
		_uiSystem = uiSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _uiSystem.OpenAsync<SplashScreenView, SplashScreenViewModel>(ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _uiSystem.CloseAsync<SplashScreenView>(ct);
	}

	#endregion
}

}