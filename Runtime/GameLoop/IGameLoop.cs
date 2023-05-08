namespace EM.GameKit
{

using Foundation;

public interface IGameLoop
{
	void CreateGameLoopComponent();

	void Run(object key);

	void Stop(object key);

	IGameLoopBindingLifeTime Bind(object key);

	bool Unbind(object key);

	void Unbind(LifeTime lifeTime);
}

}