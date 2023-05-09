namespace EM.GameKit
{

using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(SplashScreenView), LifeTime.Local)]
public sealed class SplashScreenView : View<ISplashScreenViewModel>
{
	[SerializeField]
	private Button _skipButton;

	[SerializeField]
	private List<SplashView> _splashes;

	private SplashView _currentSplashView;

	private CancellationTokenSource _cts;

	#region View

	protected override void OnInitialize()
	{
		base.OnInitialize();

		ViewModel.CurrentSplashName.Subscribe(ChangeSplash, CtsInstance);
		_skipButton.Subscribe(ViewModel.Skip, CtsInstance);

		ViewModel.Next();
	}

	#endregion

	#region SplashScreenView

	private void ChangeSplash(string splash)
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

	private async UniTask ShowAsync(string splash)
	{
		if (splash == null)
		{
			return;
		}

		if (TryGetView(splash, out var splashView))
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