namespace EM.GameKit
{
	
using UI;
using UnityEngine;

public sealed class GdpRegulationViewModel : IGdpRegulationViewModel
{
	private readonly GdpRegulationModel _gdpRegulationModel;

	private readonly IGdpRegulationConfigProvider _configsProvider;

	#region IGdpRegulationViewModel
	
	void IViewModel.Initialize()
	{
	}

	void IViewModel.Release()
	{
	}

	public void Accept()
	{
		_gdpRegulationModel.Accept();
	}

	public void OpenPrivacy()
	{
		Application.OpenURL(_configsProvider.PrivacyUrl);
	}

	public void OpenLicence()
	{
		Application.OpenURL(_configsProvider.LicenseUrl);
	}

	#endregion

	#region GdpRegulationViewModel

	public GdpRegulationViewModel(GdpRegulationModel gdpRegulationModel,
		IGdpRegulationConfigProvider configsProvider)
	{
		_gdpRegulationModel = gdpRegulationModel;
		_configsProvider = configsProvider;
	}

	#endregion
}

}