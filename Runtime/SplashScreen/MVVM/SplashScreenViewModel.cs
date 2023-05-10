namespace EM.GameKit
{

using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;

public sealed class SplashScreenViewModel : ISplashScreenViewModel
{
	private readonly SplashScreenModel _model;

	private readonly AsyncRxProperty<string> _currentSplashName = new();
	
	private readonly Queue<string> _splashNameQueue = new();
	
	private CancellationTokenSource _cts;

	#region ISplashScreenUiViewModel

	public IAsyncRxProperty<string> CurrentSplashName => _currentSplashName;

	public void Show()
	{
		if (_splashNameQueue.TryDequeue(out var splash))
		{
			ShowAsync(splash).Forget();
			WaitCancelAsync().Forget();
		}
		else
		{
			ShowAsync(null).Forget();
			_model.Finish();
		}
	}

	public void Skip()
	{
		_cts?.Cancel();
	}

	#endregion

	#region SplashScreenViewModel

	public SplashScreenViewModel(SplashScreenModel model,
		SplashScreenConfig config)
	{
		_model = model;

		if (config.Splashes == null)
		{
			return;
		}

		foreach (var splash in config.Splashes)
		{
			_splashNameQueue.Enqueue(splash.Name);
		}
	}

	private async UniTask ShowAsync(string splash)
	{
		_cts = new CancellationTokenSource();
		await _currentSplashName.SetValueAsync(splash, _cts.Token);
		_cts.Cancel();
	}
	
	private async UniTask WaitCancelAsync()
	{
		await _cts.Token.WaitUntilCanceled();
		Show();
	}
	
	#endregion
}

}