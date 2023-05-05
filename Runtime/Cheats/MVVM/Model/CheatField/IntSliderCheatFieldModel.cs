namespace EM.GameKit
{

using System;

public sealed class IntSliderCheatFieldModel : ICheatFieldModel
{
	public readonly string Label;

	public readonly int MinLimit;

	public readonly int MaxLimit;

	private int _value;

	public event Action OnChanged;

	#region IntSliderCheatFieldModel

	public IntSliderCheatFieldModel(string label,
		int minLimit,
		int maxLimit,
		int defaultValue = 0)
	{
		Label = label;
		MinLimit = minLimit;
		MaxLimit = maxLimit;
		Value = defaultValue;
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