namespace EM.GameKit
{

using UI;
using System.Threading;
using Cysharp.Threading.Tasks;

public sealed class InternetConnectionViewModel : IInternetConnectionViewModel
{
	private readonly InternetConnectionRouter _router;

	#region IInternetConnectionViewModel
	
	void IViewModel.Initialize()
	{
	}

	void IViewModel.Release()
	{
	}

	public void Restart()
	{
		_router.CloseAsync(new CancellationToken()).Forget();
	}

	#endregion

	#region InternetConnectionViewModel

	public InternetConnectionViewModel(InternetConnectionRouter router)
	{
		_router = router;
	}

	#endregion
}

}