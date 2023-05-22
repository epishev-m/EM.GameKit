namespace EM.GameKit
{

using Foundation;
using UI;

public interface ISplashScreenViewModel : IViewModel
{
	IObservableFieldAsync<string> CurrentSplashName
	{
		get;
	}

	void Skip();
}

}