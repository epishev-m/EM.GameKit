namespace EM.GameKit
{

using Foundation;

public sealed class MinMaxSliderFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<float> _minValue = new();

	private readonly RxProperty<float> _maxValue = new();

	private readonly MinMaxSliderCheatFieldModel _model;

	#region MinMaxSliderFieldViewModel

	void IFieldViewModel.Initialize()
	{
		_model.OnChanged += OnChangeModel;
	}

	void IFieldViewModel.Release()
	{
		_model.OnChanged -= OnChangeModel;
	}

	void IFieldViewModel.UpdateAllRxProperties()
	{
		OnChangeModel();
	}

	#endregion

	#region MinMaxSliderFieldViewModel

	public MinMaxSliderFieldViewModel(MinMaxSliderCheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<float> MinValue => _minValue;

	public IRxProperty<float> MaxValue => _maxValue;

	public float MinLimit => _model.MinLimit;

	public float MaxLimit => _model.MaxLimit;

	public float MinDistance => _model.MinDistance;

	public string Label => _model.Label;

	public void SetMinValue(float value)
	{
		_minValue.SetValueWithoutNotify(value);
		_model.SetMinValueWithoutNotify(value);
	}

	public void SetMaxValue(float value)
	{
		_maxValue.SetValueWithoutNotify(value);
		_model.SetMaxValueWithoutNotify(value);
	}

	private void OnChangeModel()
	{
		_minValue.Value = _model.MinValue;
		_maxValue.Value = _model.MaxValue;
	}

	#endregion
}

}