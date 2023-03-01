namespace EM.GameKit
{

using IoC;

public sealed class SplashScreenInstaller : IInstaller
{
	public void InstallBindings(IDiContainer diContainer)
	{
		diContainer.Bind<SplashScreenModel>()
			.InLocal()
			.To<SplashScreenModel>()
			.ToSingleton();

		diContainer.Bind<SplashScreenRouter>()
			.InLocal()
			.To<SplashScreenRouter>()
			.ToSingleton();

		diContainer.Bind<SplashScreenViewModel>()
			.InLocal()
			.To<SplashScreenViewModel>();

		diContainer.Bind<SplashScreen>()
			.InLocal()
			.To<SplashScreen>()
			.ToSingleton();
	}
}

}