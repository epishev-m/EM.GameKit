namespace EM.GameKit
{

using System;

public sealed class BoolCheatFieldModel : ICheatFieldModel
{
	private bool _value;

	public readonly string Label;

	public event Action OnChanged;

	#region CheatIntField

	public BoolCheatFieldModel(string label,
		bool defaultValue = false)
	{
		Label = label;
		_value = defaultValue;
	}

	public bool Value
	{
		get => _value;
		set
		{
			if (Equals(value, _value))
			{
				return;
			}

			_value = value;
			OnChanged?.Invoke();
		}
	}

	public void SetValueWithoutNotify(bool value)
	{
		_value = value;
	}

	#endregion
}

}