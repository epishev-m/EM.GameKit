namespace EM.GameKit
{

using Foundation;

public interface ISplashScreenViewModel
{
	IRxProperty<string> CurrentSplashName
	{
		get;
	}

	void Next();

	void Skip();
}

}