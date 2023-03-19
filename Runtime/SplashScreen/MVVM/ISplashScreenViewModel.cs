namespace EM.GameKit
{

using Foundation;

public interface ISplashScreenViewModel
{
	IRxProperty<SplashConfig> CurrentSplash
	{
		get;
	}

	void Next();

	void Skip();
}

}