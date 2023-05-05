namespace EM.GameKit
{

using Foundation;
using Leopotam.EcsLite;

public static class EcsWorldContextExtensions
{
	public static Context BindEcsWorld(this Context context)
	{
		var lifeTime = context.IsGlobalContext ? LifeTime.Global : LifeTime.Local;

		context.DiContainer
			.Bind<EcsWorld>()
			.SetLifeTime(lifeTime)
			.To<EcsWorld>()
			.ToSingleton();

		return context;
	}
}

}