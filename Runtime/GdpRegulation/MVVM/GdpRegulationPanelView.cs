namespace EM.GameKit
{

using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(GdpRegulationPanelView), LifeTime.Local)]
public sealed class GdpRegulationPanelView : PanelView<IGdpRegulationViewModel>
{
	[Header(nameof(GdpRegulationPanelView))]

	[SerializeField]
	private Button _licenseButton;

	[SerializeField]
	private Button _privacyButton;

	[SerializeField]
	private Button _acceptButton;

	#region View

	protected override void OnInitialize()
	{
		base.OnInitialize();

		this.Subscribe(_licenseButton, ViewModel.OpenLicence, CtsInstance);
		this.Subscribe(_privacyButton, ViewModel.OpenPrivacy, CtsInstance);
		this.Subscribe(_acceptButton, ViewModel.Accept, CtsInstance);
	}

	#endregion
}

}