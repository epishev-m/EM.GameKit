namespace EM.GameKit
{

using Foundation;
using IoC;
using Leopotam.EcsLite;

public abstract class EcsRunner : IEcsRunner
{
	private readonly IDiContainer _diContainer;

	private readonly IEcsSystems _ecsSystems;

	#region IEcsRunner

	public void Initialize()
	{
		RegisterEcsSystems();
		InitializeSystems();
	}

	public void Release()
	{
		_ecsSystems.Destroy();
	}

	public void Update()
	{
		_ecsSystems?.Run();
	}

	#endregion

	#region EcsRunner

	protected EcsRunner(IDiContainer diContainer,
		EcsWorld ecsWorld)
	{
		_diContainer = diContainer;
		_ecsSystems = new EcsSystems(ecsWorld);
	}

	protected abstract void RegisterEcsSystems();

	protected void AddEcsSystems(IEcsSystem ecsSystem)
	{
		Requires.NotNull(ecsSystem, nameof(ecsSystem));

		_ecsSystems.Add(ecsSystem);
	}

	protected void AddEcsSystems<T>()
		where T : class, IEcsSystemFactory
	{
		var ecsSystemFactory = _diContainer.Resolve<T>();
		ecsSystemFactory.CreateSystems(_ecsSystems);
	}

	private void InitializeSystems()
	{
		_ecsSystems.Init();
	}

	#endregion
}

}