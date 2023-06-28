namespace EM.GameKit
{

using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using Foundation;
using UI;

[ViewAsset(nameof(HintTooltipView), LifeTime.Local)]
public sealed class HintTooltipView : View<BaseHintTooltipViewModel>
{
	[Header(nameof(HintTooltipView))]

	[SerializeField]
	private CanvasGroup _container;

	[SerializeField]
	private TextMeshProUGUI _text;

	[SerializeField]
	private float _offset;

	[SerializeField]
	private float _duration;

	#region View

	protected override void OnInitialize()
	{
		base.OnInitialize();
		_text.text = ViewModel.Message;
		StartShowAnimation();
	}

	#endregion

	#region HintTooltipView

	private void StartShowAnimation()
	{
		_container.alpha = 0;
		_container.DOFade(1, _duration/2)
			.SetLoops(2, LoopType.Yoyo)
			.ToUniTask(cancellationToken: CtsInstance.Token)
			.Forget();

		_container.transform.localPosition = new Vector3(0f, - _offset);
		_container.transform.DOLocalMove(new Vector3(0f, _offset), _duration)
			.ToUniTask(cancellationToken: CtsInstance.Token)
			.Forget();
	}

	#endregion
}

}