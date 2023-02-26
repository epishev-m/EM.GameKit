namespace EM.GameKit
{

using Leopotam.EcsLite;

public interface IEcsSystemFactory
{
	void CreateSystems(IEcsSystems ecsSystems);
}

}