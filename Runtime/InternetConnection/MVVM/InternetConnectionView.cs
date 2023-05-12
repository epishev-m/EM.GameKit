namespace EM.GameKit
{

using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(InternetConnectionView), LifeTime.Local)]
public sealed class InternetConnectionView : View<IInternetConnectionViewModel>
{
	[Header(nameof(InternetConnectionView))]

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