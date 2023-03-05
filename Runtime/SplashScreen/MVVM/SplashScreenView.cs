namespace EM.GameKit
{

using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[Asset(nameof(SplashScreenView), LifeTime.Local)]
public sealed class SplashScreenView : View<ISplashScreenViewModel>,
	IDisposable
{
	[SerializeField] private Button _skipButton;

	[SerializeField] private List<SplashView> _splashes;

	private SplashView _currentSplashView;

	private CancellationTokenSource _cts;

	#region IDisposable

	public void Dispose()
	{
		_skipButton.onClick.RemoveAllListeners();
	}

	#endregion

	#region View

	protected override void OnInitialize()
	{
		_skipButton.onClick.AddListener(ViewModel.Skip);
		Subscribe(ViewModel.CurrentSplash, ChangeSplash);
		ViewModel.Next();
	}

	#endregion

	#region SplashScreenView

	private void ChangeSplash(ISplashConfig splash)
	{
		HideCurrent();
		ShowAsync(splash).Forget();
	}

	private void HideCurrent()
	{
		if (_currentSplashView == null)
		{
			return;
		}

		_cts.Cancel();
		_currentSplashView.Hide();
		_currentSplashView = null;
	}

	private async UniTask ShowAsync(ISplashConfig splash)
	{
		if (splash == null)
		{
			return;
		}
		
		if (TryGetView(splash.Name, out var splashView))
		{
			_currentSplashView = splashView;

			if (_currentSplashView != null)
			{
				_cts = new CancellationTokenSource();
				await _currentSplashView.ShowAsync(_cts.Token);
			}
		}

		ViewModel.Next();
	}

	private bool TryGetView(string splashName,
		out SplashView splashView)
	{
		splashView = _splashes.Find(item => item.Name == splashName);

		if (splashView != null)
		{
			return true;
		}

		Debug.LogWarning($"Splash with name {splashName} not found");

		return false;
	}

	#endregion
}

}