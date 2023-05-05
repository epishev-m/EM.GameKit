namespace EM.GameKit
{

using System;

public sealed class SliderCheatFieldModel : ICheatFieldModel
{
	public readonly string Label;

	public readonly float MinValue;

	public readonly float MaxValue;

	private float _value;

	public event Action OnChanged;

	#region SliderCheatFieldModel

	public SliderCheatFieldModel(string label,
		float minValue,
		float maxValue,
		float defaultValue = 0)
	{
		Label = label;
		MinValue = minValue;
		MaxValue = maxValue;
		Value = defaultValue;
	}

	public float Value
	{
		get => _value;
		set
		{
			var result = Math.Min(Math.Max(value, MinValue), MaxValue);

			if (Equals(result, _value))
			{
				return;
			}

			_value = value;
			OnChanged?.Invoke();
		}
	}

	public void SetValueWithoutNotify(float value)
	{
		var result = Math.Min(Math.Max(value, MinValue), MaxValue);
		_value = result;
	}

	#endregion
}

}