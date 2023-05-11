namespace EM.GameKit
{

using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;

public sealed class SplashScreenViewModel : ISplashScreenViewModel
{
	private readonly SplashScreenModel _model;

	private readonly ISplashScreenConfigProvider _configProvider;

	private readonly AsyncRxProperty<string> _currentSplashName = new();

	private Queue<string> _splashNameQueue;

	private CancellationTokenSource _cts;

	#region ISplashScreenUiViewModel

	public IAsyncRxProperty<string> CurrentSplashName => _currentSplashName;

	public void Show()
	{
		FillSplashNameQueue();

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
		if (_configProvider.CheckSkipByName(_currentSplashName.Value))
		{
			_cts?.Cancel();
		}
	}

	#endregion

	#region SplashScreenViewModel

	public SplashScreenViewModel(SplashScreenModel model,
		ISplashScreenConfigProvider configProvider)
	{
		_model = model;
		_configProvider = configProvider;
	}

	private void FillSplashNameQueue()
	{
		if (_splashNameQueue != null)
		{
			return;
		}

		_splashNameQueue = _configProvider.GetSplashNameQueue();
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