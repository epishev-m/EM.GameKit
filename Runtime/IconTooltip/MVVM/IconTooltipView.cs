﻿namespace EM.GameKit
{

using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Foundation;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(IconTooltipView), LifeTime.Local)]
public sealed class IconTooltipView : View<BaseIconTooltipViewModel>
{
	[Header(nameof(IconTooltipView))]

	[SerializeField]
	private IconView _icon;

	[SerializeField]
	private RectTransform _substrate;

	[SerializeField]
	private CanvasGroup _substrateCanvasGroup;

	[SerializeField]
	private RectTransform _pointer;

	[SerializeField]
	private TextMeshProUGUI _header;

	[SerializeField]
	private TextMeshProUGUI _description;

	[SerializeField]
	private float _substrateOffset;

	[SerializeField]
	private float _substrateAnimationOffset;

	[SerializeField]
	private float _borderOffset;

	#region View

	protected override void OnInitialize()
	{
		base.OnInitialize();
		SetIcon();
		SetContent();
		SetSubstratePosition();
		StartShowAnimation();
	}

	#endregion

	#region CurrencyTooltipView
	
	private void SetIcon()
	{
		_icon.SetImageAsync(ViewModel.Icon).Forget();
		_icon.SetSize(ViewModel.Size);
		_icon.transform.position = new Vector3(ViewModel.Position.x, ViewModel.Position.y);
	}

	private void SetContent()
	{
		_header.text = ViewModel.Title;
		_description.text = ViewModel.Description;
		LayoutRebuilder.ForceRebuildLayoutImmediate(_substrate);
	}

	private void SetSubstratePosition()
	{
		var substrateRect = _substrate.rect;
		var offset = ViewModel.Size.y / 2 + substrateRect.height / 2 + _substrateOffset;

		var upperHalfScreen = IsUpperHalfScreen;

		var substratePosition = upperHalfScreen
			? new Vector2(ViewModel.Position.x, ViewModel.Position.y - offset) 
			: new Vector2(ViewModel.Position.x, ViewModel.Position.y + offset);

		var halfSubstrateSizeX  = substrateRect.size.x / 2;
		var halfSubstrateSizeY  = substrateRect.size.y / 2;

		var pointerRotationZ = upperHalfScreen ? 180f : 0f;
		var pointerPosition = upperHalfScreen
			? new Vector2(ViewModel.Position.x, substratePosition.y + halfSubstrateSizeY) 
			: new Vector2(ViewModel.Position.x, substratePosition.y - halfSubstrateSizeY);

		if (substratePosition.x + halfSubstrateSizeX > Screen.width)
		{
			substratePosition.x = Screen.width - halfSubstrateSizeX - _borderOffset;
		}
		else if (substratePosition.x - halfSubstrateSizeX < 0)
		{
			substratePosition.x = halfSubstrateSizeX + _borderOffset;
		}

		_substrate.position = new Vector3(substratePosition.x, substratePosition.y);
		_pointer.position = new Vector3(pointerPosition.x, pointerPosition.y);
		_pointer.Rotate(0f, 0f, pointerRotationZ);
	}

	private void StartShowAnimation()
	{
		_icon.transform.DOPunchScale(Vector3.one, 0.7f, 8, 0);
		_icon.CoverColor = Color.white;
		_icon.CoverAmount = 0;
		DOTween.To(value => _icon.CoverAmount = value, _icon.CoverAmount, 1f, 0.1f)
			.SetLoops(2, LoopType.Yoyo);

		var offset = IsUpperHalfScreen ? -_substrateAnimationOffset : _substrateAnimationOffset;
		var position = _substrate.position;
		_substrate.position = new Vector3(position.x, position.y + offset);
		_substrate.DOMoveY(position.y, 0.5f);

		_substrateCanvasGroup.alpha = 0;
		_substrateCanvasGroup.DOFade(1, 0.4f);
	}

	private bool IsUpperHalfScreen
	{
		get
		{
			return ViewModel.Layouts switch
			{
				IconTooltipLayouts.Auto => ViewModel.Position.y > Screen.height / 2f,
				IconTooltipLayouts.Above => true,
				IconTooltipLayouts.Below => false,
				_ => throw new ArgumentOutOfRangeException()
			};
		}
	}
	
	#endregion
}

}