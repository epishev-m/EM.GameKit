namespace EM.GameKit
{

using System.Collections.Generic;

public interface ICheatBindingGroup
{
	IEnumerable<string> Groups { get; }

	ICheatBinding SetGroups(params string[] groups);
}

}