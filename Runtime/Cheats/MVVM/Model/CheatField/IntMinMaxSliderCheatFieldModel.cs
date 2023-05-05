namespace EM.GameKit
{

using System;

public sealed class IntMinMaxSliderCheatFieldModel : ICheatFieldModel
{
	public readonly string Label;

	public readonly int MinLimit;

	public readonly int MaxLimit;

	public readonly int MinDistance; 

	private int _minValue;

	private int _maxValue;

	public event Action OnChanged;

	#region MinMaxSliderCheatFieldModel

	public IntMinMaxSliderCheatFieldModel(string label,
		int minLimit,
		int maxLimit,
		int minDistance)
	{
		Label = label;
		MinLimit = minLimit;
		MaxLimit = maxLimit;
		_minValue = MinLimit;
		_maxValue = MaxLimit;
		MinDistance = minDistance;
	}

	public int MinValue
	{
		get => _minValue;
		set
		{
			var result = Math.Min(Math.Max(value, MinLimit), MaxLimit);

			if (Equals(result, _minValue))
			{
				return;
			}

			_minValue = value;
			OnChanged?.Invoke();
		}
	}

	public int MaxValue
	{
		get => _maxValue;
		set
		{
			var result = Math.Min(Math.Max(value, MinLimit), MaxLimit);

			if (Equals(result, _maxValue))
			{
				return;
			}

			_maxValue = value;
			OnChanged?.Invoke();
		}
	}

	public void SetMinValueWithoutNotify(int value)
	{
		var result = Math.Min(Math.Max(value, MinLimit), MaxLimit);
		_minValue = result;
	}

	public void SetMaxValueWithoutNotify(int value)
	{
		var result = Math.Min(Math.Max(value, MinLimit), MaxLimit);
		_maxValue = result;
	}

	#endregion
}

}