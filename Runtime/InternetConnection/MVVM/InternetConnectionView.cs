namespace EM.GameKit
{

using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[Asset(nameof(InternetConnectionView), LifeTime.Local)]
public sealed class InternetConnectionView : View<IInternetConnectionViewModel>
{
	[Header(nameof(InternetConnectionView))]

	[SerializeField]
	private Button _restartButton;

	#region PanelView

	protected override void OnInitialize()
	{
		base.OnInitialize();

		Subscribe(_restartButton.onClick, ViewModel.Restart);
	}

	#endregion
}

}