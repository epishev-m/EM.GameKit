namespace EM.GameKit
{

using Foundation;

public interface ISplashScreenViewModel
{
	IObservableFieldAsync<string> CurrentSplashName
	{
		get;
	}

	void Show();
	
	void Skip();
}

}