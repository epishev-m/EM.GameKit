namespace EM.GameKit
{

public interface IGdpRegulationConfigProvider
{
	bool IsUsed { get; }

	string PrivacyUrl { get; }

	string LicenseUrl { get; }
}

}