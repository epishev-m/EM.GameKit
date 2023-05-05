namespace EM.GameKit
{

using Foundation;

public static class CheatsDiContainerExtensions
{
	public static Context BindCheats(this Context context)
	{
		var lifeTime = context.IsGlobalContext ? LifeTime.Global : LifeTime.Local;

		context.DiContainer
			.Bind<ICheatBinder>()
			.SetLifeTime(lifeTime)
			.To<CheatBinder>()
			.ToSingleton();

		context.DiContainer
			.Bind<CheatsModel>()
			.SetLifeTime(lifeTime)
			.To<CheatsModel>()
			.ToSingleton();

		context.DiContainer
			.Bind<Cheats>()
			.SetLifeTime(lifeTime)
			.To<Cheats>()
			.ToSingleton();

		context.DiContainer
			.Bind<CheatTest>()
			.SetLifeTime(lifeTime)
			.To<CheatTest>()
			.ToSingleton();

		context.DiContainer
			.Bind<CheatsRouter>()
			.SetLifeTime(lifeTime)
			.To<CheatsRouter>()
			.ToSingleton();

		context.DiContainer
			.Bind<CheatsViewModel>()
			.SetLifeTime(lifeTime)
			.To<CheatsViewModel>();

		return context;
	}

	public static Context UseTestCheats(this Context context)
	{
		context.DiContainer
			.Resolve<Cheats>()
			.Add<CheatTest>();

		return context;
	}
}

}