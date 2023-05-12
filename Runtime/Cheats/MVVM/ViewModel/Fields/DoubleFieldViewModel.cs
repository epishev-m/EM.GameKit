namespace EM.GameKit
{

using Foundation;

public sealed class DoubleFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<double> _value = new();

	private readonly ObservableField<string> _label = new();

	private readonly DoubleCheatFieldModel _model;

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

	#region DoubleFieldViewModel

	public DoubleFieldViewModel(DoubleCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<double> Value => _value;

	public IObservableField<string> Label => _label;

	public void SetValue(double value)
	{
		_value.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(value);
	}

	private void OnChangeModel()
	{
		_label.SetValue(_model.Label);
		_value.SetValue(_model.Value);
	}

	#endregion
}

}