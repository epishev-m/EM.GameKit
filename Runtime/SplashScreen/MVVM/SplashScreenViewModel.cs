namespace EM.GameKit
{

using System;
using System.Collections.Generic;
using Foundation;
using UnityEngine;

public class SplashScreenViewModel : ISplashScreenViewModel,
	IDisposable
{
	private readonly SplashScreenModel _model;

	private readonly RxProperty<ISplashConfig> _currentSplash = new();

	private readonly Queue<ISplashConfig> _splashQueue = new();

	#region IDisposable

	public void Dispose()
	{
		_model.OnStarted -= Next;
		_splashQueue.Clear();
	}

	#endregion

	#region ISplashScreenUiViewModel

	public IRxProperty<ISplashConfig> CurrentSplash => _currentSplash;

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
		_model.OnStarted += Next;

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