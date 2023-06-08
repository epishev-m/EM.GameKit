namespace EM.GameKit
{

using Foundation;

public interface ICheat
{
	void Registration(ICheatBinder cheatBinder,
		LifeTime lifeTime);
}

}