namespace EM.GameKit
{

using IoC;
using UI;

public sealed class ViewModelFactory : IViewModelFactory
{
	private readonly IDiContainer _diContainer;

	public TViewModel Get<TViewModel>()
		where TViewModel : class
	{
		return _diContainer.Resolve<TViewModel>();
	}
	
	#region ViewModelFactory

	public ViewModelFactory(IDiContainer diContainer)
	{
		_diContainer = diContainer;
	}

	#endregion
}

}