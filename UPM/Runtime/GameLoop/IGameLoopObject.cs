namespace EM.GameKit
{

public interface IGameLoopObject
{
	void Initialize();

	void TurnOn();

	void Tick(float deltaTime);

	void TurnOff();

	void Release();
}

}