namespace EM.GameKit
{

using System.Collections.Generic;

public interface ISplashScreenConfigProvider
{
	bool IsUsed
	{
		get;
	}

	Queue<string> GetSplashNameQueue();

	bool CheckSkipByName(string name);
}

}