namespace EM.GameKit
{

using Leopotam.EcsLite;

public sealed class DebugEcsRunner : EcsRunner
{
	#region EcsRunner

	protected override void OnInitialized()
	{
		EcsSystems.Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
	}

	#endregion

	#region DebugEcsRunner

	public DebugEcsRunner(EcsWorld ecsWorld)
		: base(ecsWorld)
	{
	}

	#endregion
}

}