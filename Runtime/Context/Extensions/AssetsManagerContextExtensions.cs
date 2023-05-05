namespace EM.GameKit
{

using Foundation;

public static class AssetsManagerContextExtensions
{
	public static Context BindAssetsManager(this Context context)
	{
		var lifeTime = context.IsGlobalContext ? LifeTime.Global : LifeTime.Local;

		context.DiContainer
			.Bind<IAssetsManager>()
			.SetLifeTime(lifeTime)
			.To<AssetsManager>()
			.ToSingleton();

		return context;
	}
}

}