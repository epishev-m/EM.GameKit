namespace EM.GameKit
{

using System;

public sealed class DoubleCheatFieldModel : ICheatFieldModel
{
	private double _value;

	public readonly string Label;

	public event Action OnChanged;

	#region CheatIntField

	public DoubleCheatFieldModel(string label,
		double defaultValue = 0)
	{
		Label = label;
		_value = defaultValue;
	}

	public double Value
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

	public void SetValueWithoutNotify(double value)
	{
		_value = value;
	}

	#endregion
}

}