namespace EM.GameKit
{

using Foundation;

public static class GameLoopContextExtensions
{
	public static Context AddGameLoop(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Bind<IGameLoopObjectFactory>()
			.SetLifeTime(lifeTime)
			.To<GameLoopObjectFactory>()
			.ToSingleton();

		context.DiContainer
			.Bind<IGameLoop>()
			.SetLifeTime(lifeTime)
			.To<GameLoop>()
			.ToSingleton();

		return context;
	}

	public static Context UseGameLoop(this Context context)
	{
		context.DiContainer
			.Resolve<IGameLoop>()
			.CreateGameLoopComponent();

		return context;
	}

	public static Context ReleaseGameLoop(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Resolve<IGameLoop>()
			.Unbind(lifeTime);

		return context;
	}
}

}