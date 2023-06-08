namespace EM.GameKit
{

using Foundation;

public interface ICheatBindingLifeTime
{
	LifeTime LifeTime { get; }

	ICheatBindingGroup InGlobal();

	ICheatBindingGroup InLocal();

	ICheatBindingGroup SetLifeTime(LifeTime lifeTime);
}

}