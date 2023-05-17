namespace EM.GameKit
{

using Foundation;

public sealed class MinMaxSliderFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<float> _minValue = new();

	private readonly ObservableField<float> _maxValue = new();

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

	public IObservableField<float> MinValue => _minValue;

	public IObservableField<float> MaxValue => _maxValue;

	public float MinLimit => _model.MinLimit;

	public float MaxLimit => _model.MaxLimit;

	public float MinDistance => _model.MinDistance;

	public string Label => _model.Label;

	public void SetMinValue(float value)
	{
		_minValue.SetValueWithoutNotify(value);
		_model.MinValue = value;
	}

	public void SetMaxValue(float value)
	{
		_maxValue.SetValueWithoutNotify(value);
		_model.MaxValue = value;
	}

	private void OnChangeModel()
	{
		_minValue.SetValue(_model.MinValue);
		_maxValue.SetValue(_model.MaxValue);
	}

	#endregion
}

}