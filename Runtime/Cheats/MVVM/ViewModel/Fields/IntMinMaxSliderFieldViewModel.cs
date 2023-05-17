namespace EM.GameKit
{

using Foundation;

public sealed class IntMinMaxSliderFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<int> _minValue = new();

	private readonly ObservableField<int> _maxValue = new();

	private readonly IntMinMaxSliderCheatFieldModel _model;

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

	public IntMinMaxSliderFieldViewModel(IntMinMaxSliderCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<int> MinValue => _minValue;

	public IObservableField<int> MaxValue => _maxValue;

	public int MinLimit => _model.MinLimit;

	public int MaxLimit => _model.MaxLimit;

	public int MinDistance => _model.MinDistance;

	public string Label => _model.Label;

	public void SetMinValue(int value)
	{
		_minValue.SetValueWithoutNotify(value);
		_model.MinValue = value;
	}

	public void SetMaxValue(int value)
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