namespace EM.GameKit
{

using UnityEngine;

public sealed class GdpRegulationViewModel : IGdpRegulationViewModel
{
	private readonly GdpRegulationModel _gdpRegulationModel;

	private readonly IGdpRegulationConfig _configs;

	#region IGdpRegulationViewModel

	public void Accept()
	{
		_gdpRegulationModel.Accept();
	}

	public void OpenPrivacy()
	{
		Application.OpenURL(_configs.PrivacyUrl);
	}

	public void OpenLicence()
	{
		Application.OpenURL(_configs.LicenseUrl);
	}

	#endregion

	#region GdpRegulationViewModel

	public GdpRegulationViewModel(GdpRegulationModel gdpRegulationModel,
		IGdpRegulationConfig configs)
	{
		_gdpRegulationModel = gdpRegulationModel;
		_configs = configs;
	}

	#endregion
}

}