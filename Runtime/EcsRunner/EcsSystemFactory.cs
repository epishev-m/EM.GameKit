namespace EM.GameKit
{

using Foundation;
using IoC;
using Leopotam.EcsLite;

public abstract class EcsSystemFactory : IEcsSystemFactory
{
	private readonly IDiContainer _diContainer;

	#region IEcsSystemFactory

	public abstract void CreateSystems(IEcsSystems ecsSystems);

	#endregion

	#region EcsSystemFactory

	protected EcsSystemFactory(IDiContainer diContainer)
	{
		Requires.NotNull(diContainer, nameof(diContainer));

		_diContainer = diContainer;
	}

	protected void CreateSystem<T>(IEcsSystems ecsSystems)
		where T : class, IEcsSystem
	{
		var system = _diContainer.Resolve<T>();
		ecsSystems.Add(system);
	}

	#endregion
}

}