namespace EM.GameKit
{

using Foundation;
using IoC;

public static class SplashScreenDiContainerExtensions
{
	public static IDiContainer BindSystemSplashScreen(this IDiContainer diContainer,
		LifeTime lifeTime)
	{
		diContainer.Bind<SplashScreenModel>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenModel>()
			.ToSingleton();

		diContainer.Bind<SplashScreenRouter>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenRouter>()
			.ToSingleton();

		diContainer.Bind<SplashScreenViewModel>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenViewModel>();

		diContainer.Bind<SplashScreen>()
			.SetLifeTime(lifeTime)
			.To<SplashScreen>()
			.ToSingleton();

		return diContainer;
	}
}

}