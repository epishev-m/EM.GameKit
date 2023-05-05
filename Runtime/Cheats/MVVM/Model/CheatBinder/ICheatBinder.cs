namespace EM.GameKit
{

using System.Collections.Generic;
using Foundation;

public interface ICheatBinder
{
	IEnumerable<string> GetNames();

	IEnumerable<string> GetGroupsByName(string name);

	IEnumerable<ICheatFieldModel> GetItemsByName(string name);

	ICheatBindingLifeTime Bind(string name);

	void Unbind(string name);

	void Unbind(LifeTime lifeTime);

	void UnbindAll();
}

}