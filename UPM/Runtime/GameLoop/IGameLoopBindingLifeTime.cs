namespace EM.GameKit
{

using Foundation;

public interface IGameLoopBindingLifeTime
{
	LifeTime LifeTime
	{
		get;
	}

	IGameLoopBinding InGlobal();

	IGameLoopBinding InLocal();

	IGameLoopBinding SetLifeTime(LifeTime lifeTime);
}

}