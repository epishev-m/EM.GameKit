namespace EM.GameKit
{

using System;

public sealed class MinMaxSliderCheatFieldModel : ICheatFieldModel
{
	public readonly string Label;

	public readonly float MinLimit;

	public readonly float MaxLimit;

	public readonly float MinDistance; 

	private float _minValue;

	private float _maxValue;

	public event Action OnChanged;

	#region MinMaxSliderCheatFieldModel

	public MinMaxSliderCheatFieldModel(string label,
		float minLimit,
		float maxLimit,
		float minDistance)
	{
		Label = label;
		MinLimit = minLimit;
		MaxLimit = maxLimit;
		_minValue = MinLimit;
		_maxValue = MaxLimit;
		MinDistance = minDistance;
	}

	public float MinValue
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

	public float MaxValue
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

	public void SetMinValueWithoutNotify(float value)
	{
		var result = Math.Min(Math.Max(value, MinLimit), MaxLimit);
		_minValue = result;
	}

	public void SetMaxValueWithoutNotify(float value)
	{
		var result = Math.Min(Math.Max(value, MinLimit), MaxLimit);
		_maxValue = result;
	}

	#endregion
}

}