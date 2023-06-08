namespace EM.GameKit
{

using System;
using System.Collections.Generic;
using Foundation;

public sealed class CheatBinding : Binding,
	ICheatBindingLifeTime,
	ICheatBindingGroup,
	ICheatBinding
{
	#region ICheatBinding

	ICheatBinding ICheatBinding.AddInfo(string info)
	{
		Requires.ValidOperation(Groups != null, this);

		var cheatInfoField = new InfoCheatFieldModel(info);

		return To(cheatInfoField) as ICheatBinding;
	}

	ICheatBinding ICheatBinding.AddField<T>(T field)
		where T : class
	{
		Requires.ValidOperation(LifeTime != LifeTime.None, this);
		Requires.NotNullParam(field, nameof(field));

		return To(field) as ICheatBinding;
	}

	ICheatBinding ICheatBinding.AddButton(string label,
		Action action)
	{
		Requires.ValidOperation(LifeTime != LifeTime.None, this);

		var buttonItem = new ButtonCheatFieldModel(label, action);

		return To(buttonItem) as ICheatBinding;
	}

	ICheatBinding ICheatBinding.AddButton(string label,
		Action action,
		string label2,
		Action action2)
	{
		Requires.ValidOperation(LifeTime != LifeTime.None, this);

		var buttonItem = new Button2CheatFieldModel(label, action, label2, action2);

		return To(buttonItem) as ICheatBinding;
	}

	ICheatBinding ICheatBinding.AddButton(string label,
		Action action,
		string label2,
		Action action2,
		string label3,
		Action action3)
	{
		
		Requires.ValidOperation(LifeTime != LifeTime.None, this);

		var buttonItem = new Button3CheatFieldModel(label, action, label2, action2, label3, action3);

		return To(buttonItem) as ICheatBinding;
	}

	#endregion

	#region ICheatBindingGroup

	public IEnumerable<string> Groups { get; private set; }

	ICheatBinding ICheatBindingGroup.SetGroups(params string[] groups)
	{
		Requires.ValidOperation(LifeTime != LifeTime.None, this);
		Requires.ValidOperation(Groups == null, this);
		Requires.NotNullParam(groups, nameof(groups));

		Groups = groups;

		return this;
	}

	#endregion

	#region ICheatBindingLifeTime

	public LifeTime LifeTime { get; private set; } = LifeTime.None;

	ICheatBindingGroup ICheatBindingLifeTime.InGlobal()
	{
		Requires.ValidOperation(LifeTime == LifeTime.None, this);

		LifeTime = LifeTime.Global;

		return this;
	}

	ICheatBindingGroup ICheatBindingLifeTime.InLocal()
	{
		Requires.ValidOperation(LifeTime == LifeTime.None, this);

		LifeTime = LifeTime.Local;

		return this;
	}

	ICheatBindingGroup ICheatBindingLifeTime.SetLifeTime(LifeTime lifeTime)
	{
		Requires.ValidOperation(LifeTime == LifeTime.None, this);

		LifeTime = lifeTime;

		return this;
	}

	#endregion

	#region Binding

	public CheatBinding(object key,
		object name,
		Resolver resolver) : base(key, name, resolver)
	{
	}

	#endregion
}

}