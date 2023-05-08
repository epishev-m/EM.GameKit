namespace EM.GameKit
{

using Foundation;

public static class GdpRegulationContextExtensions
{
	public static Context BindSystemGdpRegulation(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Bind<GdpRegulationModel>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationModel>()
			.ToSingleton();

		context.DiContainer
			.Bind<GdpRegulationSaver>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationSaver>()
			.ToSingleton();

		context.DiContainer
			.Bind<GdpRegulationRouter>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationRouter>()
			.ToSingleton();

		context.DiContainer
			.Bind<GdpRegulationViewModel>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationViewModel>();

		context.DiContainer
			.Bind<GdpRegulation>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulation>()
			.ToSingleton();

		return context;
	}
}

}