namespace EM.GameKit
{

using IoC;
using Leopotam.EcsLite;

public class EcsWorldInstaller : IInstaller
{
	public void InstallBindings(IDiContainer diContainer)
	{
		diContainer.Bind<EcsWorld>()
			.InGlobal()
			.To<EcsWorld>()
			.ToSingleton();
	}
}

}