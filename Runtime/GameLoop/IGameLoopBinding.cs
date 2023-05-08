namespace EM.GameKit
{

public interface IGameLoopBinding
{
	IGameLoopBinding To<T>()
		where T : class, IGameLoopObject;
}

}