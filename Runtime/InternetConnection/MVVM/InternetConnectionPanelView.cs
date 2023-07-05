namespace EM.GameKit
{

using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(InternetConnectionPanelView), LifeTime.Local)]
public sealed class InternetConnectionPanelView : PanelView<IInternetConnectionViewModel>
{
	[Header(nameof(InternetConnectionPanelView))]

	[SerializeField]
	private Button _restartButton;

	#region PanelView

	protected override void OnInitialize()
	{
		base.OnInitialize();

		this.Subscribe(_restartButton, ViewModel.Restart, CtsInstance);
	}

	#endregion
}

}