namespace EM.GameKit
{

using System;

public sealed class TextCheatFieldModel : ICheatFieldModel
{
	private string _value;

	public readonly string Label;

	public event Action OnChanged;

	#region TextCheatFieldModel

	public TextCheatFieldModel(string label,
		string defaultValue = "")
	{
		Label = label;
		_value = defaultValue;
	}

	public string Value
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

	public void SetValueWithoutNotify(string value)
	{
		_value = value;
	}

	#endregion
}

}