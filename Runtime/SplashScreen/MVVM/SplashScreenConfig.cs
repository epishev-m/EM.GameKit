namespace EM.GameKit
{

using System.Collections.Generic;

public sealed class SplashScreenConfig
{
	public readonly IEnumerable<SplashConfig> Splashes;

	#region SplashScreenConfig

	public SplashScreenConfig(IEnumerable<SplashConfig> splashes)
	{
		Splashes = splashes;
	}

	#endregion
}

}