namespace EM.GameKit
{

using Foundation;

public interface ISplashScreenViewModel
{
	IRxProperty<ISplashConfig> CurrentSplash
	{
		get;
	}

	void Next();

	void Skip();
}

}