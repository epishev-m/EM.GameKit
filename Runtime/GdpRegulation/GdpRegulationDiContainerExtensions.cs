namespace EM.GameKit
{

using Foundation;
using IoC;

public static class GdpRegulationDiContainerExtensions
{
	public static IDiContainer BindSystemGdpRegulation(this IDiContainer diContainer,
		LifeTime lifeTime)
	{
		diContainer.Bind<GdpRegulationModel>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationModel>()
			.ToSingleton();

		diContainer.Bind<GdpRegulationSaver>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationSaver>()
			.ToSingleton();

		diContainer.Bind<GdpRegulationRouter>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationRouter>()
			.ToSingleton();

		diContainer.Bind<GdpRegulationViewModel>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulationViewModel>();

		diContainer.Bind<GdpRegulation>()
			.SetLifeTime(lifeTime)
			.To<GdpRegulation>()
			.ToSingleton();

		return diContainer;
	}
}

}