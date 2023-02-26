namespace EM.GameKit
{

using IoC;
using Leopotam.EcsLite;

public sealed class DebugEcsRunner : EcsRunner
{
	#region EcsRunner

	protected override void RegisterEcsSystems()
	{
		AddEcsSystems(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
	}

	#endregion

	#region DebugEcsRunner

	public DebugEcsRunner(IDiContainer diContainer,
		EcsWorld ecsWorld)
		: base(diContainer, ecsWorld)
	{
	}

	#endregion
}

}