namespace EM.GameKit
{

using System;
using UnityEngine;

public sealed class Vector2CheatFieldModel : ICheatFieldModel
{
	private Vector2 _value;

	public readonly string Label;

	public event Action OnChanged;

	#region Vector2CheatFieldModel

	public Vector2CheatFieldModel(string label,
		Vector2 defaultValue = new())
	{
		Label = label;
		Value = defaultValue;
	}
	
	public Vector2 Value
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

	public void SetValueWithoutNotify(Vector2 value)
	{
		_value = value;
	}

	#endregion
}

}