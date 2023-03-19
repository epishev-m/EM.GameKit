namespace EM.GameKit
{

public sealed class SplashConfig
{
	public readonly string Name;

	public readonly bool IsSkipped;

	public SplashConfig(string name,
		bool isSkipped)
	{
		Name = name;
		IsSkipped = isSkipped;
	}
}

}