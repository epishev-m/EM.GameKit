namespace EM.GameKit
{

using System;
using UnityEngine;

public sealed class Vector3CheatFieldModel : ICheatFieldModel
{
	private Vector3 _value;

	public readonly string Label;

	public event Action OnChanged;

	#region Vector3CheatFieldModel

	public Vector3CheatFieldModel(string label,
		Vector3 defaultValue = new())
	{
		Label = label;
		Value = defaultValue;
	}

	public Vector3 Value
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

	public void SetValueWithoutNotify(Vector3 value)
	{
		_value = value;
	}

	#endregion
}

}