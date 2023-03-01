namespace EM.GameKit
{

using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class SplashViewFade : SplashView
{
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private float _showTime = 0.5f;

	[SerializeField]
	private float _demonstrateTime = 1f;

	[SerializeField]
	private float _hideTime = 0.5f;

	#region SplashView

	public override string Name => name;

	public override async UniTask ShowAsync(CancellationToken ct)
	{
		gameObject.SetActive(true);
		await _canvasGroup.DOFade(1, _showTime).WithCancellation(ct);
		await UniTask.Delay(TimeSpan.FromSeconds(_demonstrateTime), cancellationToken: ct);
		await _canvasGroup.DOFade(0, _hideTime).WithCancellation(ct);
	}

	public override void Hide()
	{
		gameObject.SetActive(false);
	}

	#endregion
}

}