namespace EM.GameKit
{

using System.Globalization;
using System.Runtime.CompilerServices;

public static class GameStatesStringResources
{
	public static string FailedToGetInstance(IGameStateFactory factory,
		[CallerMemberName] string memberName = "",
		[CallerLineNumber] int lineNumber = 0)
	{
		return string.Format(CultureInfo.InvariantCulture,
			"[Error] Failed to get instance of GameState of given type. \n {0}.{1}:{2}",
			factory.GetType(), memberName, lineNumber);
	}
}

}