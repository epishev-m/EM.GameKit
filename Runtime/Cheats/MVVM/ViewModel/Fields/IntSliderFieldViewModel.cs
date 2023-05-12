namespace EM.GameKit
{

using Foundation;

public sealed class IntSliderFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<int> _value = new();

	private readonly IntSliderCheatFieldModel _model;

	#region IFieldViewModel

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

	#region SliderFieldViewModel

	public IntSliderFieldViewModel(IntSliderCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<int> Value => _value;

	public int MinLimit => _model.MinLimit;

	public int MaxLimit => _model.MaxLimit;

	public string Label => _model.Label;

	public void SetValue(int value)
	{
		_value.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(value);
	}

	private void OnChangeModel()
	{
		_value.SetValue(_model.Value);
	}

	#endregion
}

}