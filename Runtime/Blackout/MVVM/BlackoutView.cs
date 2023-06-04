namespace EM.GameKit
{
	
using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(BlackoutView), LifeTime.Local)]
public sealed class BlackoutView : View<IBlackoutViewModel>
{
	[Header(nameof(BlackoutView))]

	[SerializeField]
	private Button _button;

	#region View

	protected override void OnInitialize()
	{
		base.OnInitialize();
		this.Subscribe(_button, ViewModel.Click, CtsInstance);
	}

	#endregion
}

}