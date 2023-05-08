namespace EM.GameKit
{

using Foundation;
using Leopotam.EcsLite;

public static class EcsContextExtensions
{
	public static Context AddEcs(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Bind<EcsWorld>()
			.SetLifeTime(lifeTime)
			.To<EcsWorld>()
			.ToSingleton();

		context.DiContainer
			.Bind<DebugEcsRunner>()
			.SetLifeTime(lifeTime)
			.To<DebugEcsRunner>()
			.ToSingleton();

		return context;
	}

	public static Context UseEcsDebug(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		var gameLoop = context.DiContainer
			.Resolve<IGameLoop>();
		
		gameLoop.Bind(typeof(DebugEcsRunner))
			.SetLifeTime(lifeTime)
			.To<DebugEcsRunner>();

		gameLoop.Run(typeof(DebugEcsRunner));

		return context;
	}
}

}