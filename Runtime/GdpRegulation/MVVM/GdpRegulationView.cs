namespace EM.GameKit
{

using System;
using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[Asset(nameof(GdpRegulationView), LifeTime.Local)]
public sealed class GdpRegulationView : View<IGdpRegulationViewModel>,
	IDisposable
{
	[Header(nameof(GdpRegulationView))]
	[SerializeField]
	private Button _licenseButton;

	[SerializeField]
	private Button _privacyButton;

	[SerializeField]
	private Button _acceptButton;

	#region IDisposable

	public void Dispose()
	{
		_licenseButton.onClick.RemoveAllListeners();
		_privacyButton.onClick.RemoveAllListeners();
		_acceptButton.onClick.RemoveAllListeners();
	}

	#endregion

	#region View

	protected override void OnInitialize()
	{
		_licenseButton.onClick.AddListener(ViewModel.OpenLicence);
		_privacyButton.onClick.AddListener(ViewModel.OpenPrivacy);
		_acceptButton.onClick.AddListener(ViewModel.Accept);
	}

	#endregion
}

}