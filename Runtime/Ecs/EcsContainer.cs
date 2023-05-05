namespace EM.GameKit
{

using System.Collections.Generic;
using Foundation;
using IoC;

public sealed class EcsContainer
{
	private static readonly List<IEcsRunner> EcsRunners = new();

	private readonly List<IEcsRunner> _localEcsRunners = new();

	private readonly IDiContainer _diContainer;

	#region EcsController
	
	public EcsContainer(IDiContainer diContainer)
	{
		_diContainer = diContainer;
	}

	public EcsContainer Add<T>(LifeTime lifeTime)
		where T : class, IEcsRunner
	{
		_diContainer.Bind<T>()
			.SetLifeTime(lifeTime)
			.To<T>()
			.ToSingleton();

		var ecsRunner = _diContainer.Resolve<T>();
		_localEcsRunners.Add(ecsRunner);
		EcsRunners.Add(ecsRunner);

		return this;
	}

	internal void Run()
	{
		foreach (var ecsRunner in _localEcsRunners)
		{
			ecsRunner.Initialize();
		}
	}

	internal static void Update()
	{
		foreach (var ecsRunner in EcsRunners)
		{
			ecsRunner.Update();
		}
	}

	internal void Destroy()
	{
		foreach (var ecsRunner in _localEcsRunners)
		{
			EcsRunners.Remove(ecsRunner);
			ecsRunner.Release();
		}

		_localEcsRunners.Clear();
	}

	#endregion
}

}