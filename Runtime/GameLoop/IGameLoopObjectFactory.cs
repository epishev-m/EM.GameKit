namespace EM.GameKit
{

using System;

public interface IGameLoopObjectFactory
{
	IGameLoopObject Get(Type type);
}

}