namespace EM.GameKit
{

using System;
using UnityEngine;

public sealed class Vector4CheatFieldModel : ICheatFieldModel
{
	private Vector4 _value;

	public readonly string Label;

	public event Action OnChanged;

	#region Vector4CheatFieldModel

	public Vector4CheatFieldModel(string label,
		Vector4 defaultValue = new())
	{
		Label = label;
		Value = defaultValue;
	}

	public Vector4 Value
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

	public void SetValueWithoutNotify(Vector4 value)
	{
		_value = value;
	}

	#endregion
}

}