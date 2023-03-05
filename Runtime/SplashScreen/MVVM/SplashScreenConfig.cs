namespace EM.GameKit
{

using System.Collections.Generic;

public sealed class SplashScreenConfig
{
	public readonly IEnumerable<ISplashConfig> Splashes;

	#region SplashScreenConfig

	public SplashScreenConfig(IEnumerable<ISplashConfig> splashes)
	{
		Splashes = splashes;
	}

	#endregion
}

}