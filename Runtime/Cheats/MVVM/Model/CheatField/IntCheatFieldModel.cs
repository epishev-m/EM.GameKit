namespace EM.GameKit
{

using System;

public sealed class IntCheatFieldModel : ICheatFieldModel
{
	private int _value;

	public readonly string Label;

	public event Action OnChanged;

	#region CheatIntField

	public IntCheatFieldModel(string label,
		int defaultValue = 0)
	{
		Label = label;
		_value = defaultValue;
	}

	public int Value
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

	public void SetValueWithoutNotify(int value)
	{
		_value = value;
	}

	#endregion
}

}