namespace EM.GameKit
{

public sealed class GdpRegulationConfig
{
	public readonly string PrivacyUrl;

	public readonly string LicenseUrl;

	public GdpRegulationConfig(string privacyUrl,
		string licenseUrl)
	{
		PrivacyUrl = privacyUrl;
		LicenseUrl = licenseUrl;
	}
}

}