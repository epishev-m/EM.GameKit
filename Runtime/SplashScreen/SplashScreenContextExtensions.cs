namespace EM.GameKit
{

using Foundation;

public static class SplashScreenContextExtensions
{
	public static Context BindSystemSplashScreen(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;
		
		context.DiContainer
			.Bind<SplashScreenModel>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenModel>()
			.ToSingleton();

		context.DiContainer
			.Bind<SplashScreenRouter>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenRouter>()
			.ToSingleton();

		context.DiContainer
			.Bind<SplashScreenViewModel>()
			.SetLifeTime(lifeTime)
			.To<SplashScreenViewModel>();

		context.DiContainer
			.Bind<SplashScreen>()
			.SetLifeTime(lifeTime)
			.To<SplashScreen>()
			.ToSingleton();

		return context;
	}
}

}