namespace EM.GameKit
{

using UnityEngine;

public sealed class GdpRegulationViewModel : IGdpRegulationViewModel
{
	private readonly GdpRegulationModel _gdpRegulationModel;

	private readonly IGdpRegulationConfigProvider _configsProvider;

	#region IGdpRegulationViewModel

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