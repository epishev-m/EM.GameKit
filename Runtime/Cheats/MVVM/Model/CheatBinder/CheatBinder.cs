namespace EM.GameKit
{

using System.Collections.Generic;
using System.Linq;
using Foundation;

public class CheatBinder : Binder,
	ICheatBinder
{
	#region ICheatBinder

	public IEnumerable<string> GetNames()
	{
		var names = Bindings.Keys.Select(key => (string) key.Item1);

		return names;
	}

	public IEnumerable<ICheatFieldModel> GetItemsByName(string name)
	{
		var binding = GetBinding(name);
		var values = binding?.Values.Select(value => (ICheatFieldModel) value);

		return values;
	}

	public IEnumerable<string> GetGroupsByName(string name)
	{
		var binding = GetBinding(name) as CheatBinding;

		return binding?.Groups;
	}

	public ICheatBindingLifeTime Bind(string name)
	{
		return base.Bind(name) as ICheatBindingLifeTime;
	}

	public void Unbind(string name)
	{
		base.Unbind(name);
	}

	public void Unbind(LifeTime lifeTime)
	{
		Unbind(binding =>
		{
			var diBinding = (CheatBinding) binding;
			var result = diBinding.LifeTime == lifeTime;

			return result;
		});
	}

	#endregion

	#region Binder

	protected override IBinding GetRawBinding(object key,
		object name)
	{
		return new CheatBinding(key, name, BindingResolver);
	}

	#endregion
}

}