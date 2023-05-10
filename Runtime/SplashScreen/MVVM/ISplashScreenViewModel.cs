namespace EM.GameKit
{

using Foundation;

public interface ISplashScreenViewModel
{
	IAsyncRxProperty<string> CurrentSplashName
	{
		get;
	}

	void Show();
	
	void Skip();
}

}