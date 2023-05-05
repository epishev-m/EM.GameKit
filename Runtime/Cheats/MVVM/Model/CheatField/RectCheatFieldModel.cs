namespace EM.GameKit
{

using System;
using UnityEngine;

public sealed class RectCheatFieldModel : ICheatFieldModel
{
	private Rect _value;

	public readonly string Label;

	public event Action OnChanged;

	#region Vector4CheatFieldModel

	public RectCheatFieldModel(string label,
		Rect defaultValue = new())
	{
		Label = label;
		Value = defaultValue;
	}

	public Rect Value
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

	public void SetValueWithoutNotify(Rect value)
	{
		_value = value;
	}

	#endregion
}

}