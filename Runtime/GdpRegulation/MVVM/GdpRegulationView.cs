namespace EM.GameKit
{

using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(GdpRegulationView), LifeTime.Local)]
public sealed class GdpRegulationView : View<IGdpRegulationViewModel>
{
	[Header(nameof(GdpRegulationView))]
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

		_licenseButton.Subscribe(ViewModel.OpenLicence, CtsInstance);
		_privacyButton.Subscribe(ViewModel.OpenPrivacy, CtsInstance);
		_acceptButton.Subscribe(ViewModel.Accept, CtsInstance);
	}

	#endregion
}

}