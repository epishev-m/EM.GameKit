namespace EM.GameKit
{

using Foundation;

public sealed class GameStateMachine : StateMachine<IGameState>,
	IGameStateMachine
{
	public GameStateMachine(IGameStateFactory stateFactory) :
		base(stateFactory)
	{
	}
}

}