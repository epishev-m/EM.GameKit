namespace EM.GameKit
{

using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(BlackoutPanelView), LifeTime.Local)]
public sealed class BlackoutPanelView : PanelView<IBlackoutViewModel>
{
	[Header(nameof(BlackoutPanelView))]

	[SerializeField]
	private Button _button;

	#region View

	protected override void OnSettingViewModel()
	{
		base.OnSettingViewModel();
		this.Subscribe(_button, ViewModel.Click, CtsInstance);
	}

	#endregion
}

}