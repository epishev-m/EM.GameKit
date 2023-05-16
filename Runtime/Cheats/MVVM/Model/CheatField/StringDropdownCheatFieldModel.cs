namespace EM.GameKit
{

using System;
using System.Linq;
using System.Collections.Generic;

public sealed class StringDropdownCheatFieldModel : ICheatFieldModel
{
	public readonly string Label;

	private readonly List<string> _options;

	private int _index;
	
	public event Action OnChanged;

	#region StringDropdownCheatFieldModel

	public StringDropdownCheatFieldModel(string label,
		IEnumerable<string> options)
	{
		Label = label;
		_options = options.ToList();
	}

	public IEnumerable<string> Options => _options;

	public int Index
	{
		get => _index;
		set
		{
			var result = Math.Clamp(value, 0, _options.Count);

			if (Equals(result, _index))
			{
				return;
			}

			_index = result;
			OnChanged?.Invoke();
		}
	}

	public string CurrentValue => _options[_index];

	public void SetIndexWithoutNotify(int index)
	{
		_index = index;
	}

	#endregion
}

}