namespace EM.GameKit
{

using System.Collections.Generic;
using Foundation;

public class SplashScreenViewModel : ISplashScreenViewModel
{
	private readonly SplashScreenModel _model;

	private readonly RxProperty<SplashConfig> _currentSplash = new();

	private readonly Queue<SplashConfig> _splashQueue = new();

	#region ISplashScreenUiViewModel

	public IRxProperty<SplashConfig> CurrentSplash => _currentSplash;

	public void Next()
	{
		if (!_splashQueue.TryDequeue(out var splash))
		{
			_model.Finish();
		}

		_currentSplash.Value = splash;
	}

	public void Skip()
	{
		if (_currentSplash.Value is {IsSkipped: false})
		{
			return;
		}

		Next();
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
			_splashQueue.Enqueue(splash);
		}
	}

	#endregion
}

}