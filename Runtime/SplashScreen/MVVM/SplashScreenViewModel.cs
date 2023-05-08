namespace EM.GameKit
{

using System.Collections.Generic;
using System.Linq;
using Foundation;

public class SplashScreenViewModel : ISplashScreenViewModel
{
	private readonly SplashScreenModel _model;

	private readonly SplashScreenConfig _config;

	private readonly RxProperty<string> _currentSplashName = new();

	private readonly Queue<string> _splashNameQueue = new();

	#region ISplashScreenUiViewModel

	public IRxProperty<string> CurrentSplashName => _currentSplashName;

	public void Next()
	{
		if (!_splashNameQueue.TryDequeue(out var splash))
		{
			_model.Finish();
		}

		_currentSplashName.Value = splash;
	}

	public void Skip()
	{
		var currentSplash = _config.Splashes.FirstOrDefault(config => config.Name == _currentSplashName.Value);

		if (currentSplash is {IsSkipped: false})
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
		_config = config;

		if (config.Splashes == null)
		{
			return;
		}

		foreach (var splash in config.Splashes)
		{
			_splashNameQueue.Enqueue(splash.Name);
		}
	}

	#endregion
}

}