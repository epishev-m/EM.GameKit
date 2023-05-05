namespace EM.GameKit
{

using System;

public sealed class FloatCheatFieldModel : ICheatFieldModel
{
	private float _value;

	public readonly string Label;

	public event Action OnChanged;

	#region CheatIntField

	public FloatCheatFieldModel(string label,
		float defaultValue = 0)
	{
		Label = label;
		_value = defaultValue;
	}

	public float Value
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

	public void SetValueWithoutNotify(float value)
	{
		_value = value;
	}

	#endregion
}

}