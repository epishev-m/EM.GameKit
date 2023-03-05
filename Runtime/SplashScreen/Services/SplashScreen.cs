namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;

public sealed class SplashScreen
{
	private readonly SplashScreenModel _model;

	private readonly SplashScreenRouter _router;

	#region SplashScreen

	public SplashScreen(SplashScreenModel model,
		SplashScreenRouter router)
	{
		_model = model;
		_router = router;
	}

	public async UniTask ShowAsync(CancellationToken ct)
	{
		if (_model.IsFinished)
		{
			return;
		}

		await _router.OpenAsync(ct);
		await UniTask.WaitUntil(() => _model.IsFinished, cancellationToken: ct);
		await _router.CloseAsync(ct);
	}

	#endregion
}

}