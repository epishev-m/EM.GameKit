namespace EM.GameKit
{

using IoC;

public sealed class InternetConnectionInstaller : IInstaller
{
	#region IInstaller

	public void InstallBindings(IDiContainer diContainer)
	{
		diContainer.Bind<InternetConnection>()
			.InLocal()
			.To<InternetConnection>()
			.ToSingleton();

		diContainer.Bind<InternetConnectionRouter>()
			.InLocal()
			.To<InternetConnectionRouter>()
			.ToSingleton();

		diContainer.Bind<InternetConnectionViewModel>()
			.InLocal()
			.To<InternetConnectionViewModel>();
	}

	#endregion
}

}