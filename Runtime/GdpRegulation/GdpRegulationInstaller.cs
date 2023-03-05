namespace EM.GameKit
{

using IoC;

public sealed class GdpRegulationInstaller : IInstaller
{
	#region IInstaller

	public void InstallBindings(IDiContainer diContainer)
	{
		diContainer.Bind<GdpRegulationModel>()
			.InLocal()
			.To<GdpRegulationModel>()
			.ToSingleton();

		diContainer.Bind<GdpRegulationSaver>()
			.InLocal()
			.To<GdpRegulationSaver>()
			.ToSingleton();

		diContainer.Bind<GdpRegulationRouter>()
			.InLocal()
			.To<GdpRegulationRouter>()
			.ToSingleton();

		diContainer.Bind<GdpRegulationViewModel>()
			.InLocal()
			.To<GdpRegulationViewModel>();

		diContainer.Bind<GdpRegulation>()
			.InLocal()
			.To<GdpRegulation>()
			.ToSingleton();
	}

	#endregion
}

}