namespace EM.GameKit
{

using System;

public sealed class LongCheatFieldModel : ICheatFieldModel
{
	private long _value;

	public readonly string Label;

	public event Action OnChanged;

	#region LongCheatFieldModel

	public LongCheatFieldModel(string label,
		long defaultValue = 0)
	{
		Label = label;
		_value = defaultValue;
	}

	public long Value
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

	public void SetValueWithoutNotify(long value)
	{
		_value = value;
	}

	#endregion
}

}