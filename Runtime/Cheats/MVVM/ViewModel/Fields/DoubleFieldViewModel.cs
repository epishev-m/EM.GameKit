namespace EM.GameKit
{

using Foundation;

public sealed class DoubleFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<double> _value = new();

	private readonly RxProperty<string> _label = new();

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

	public IRxProperty<double> Value => _value;

	public IRxProperty<string> Label => _label;

	public void SetValue(double value)
	{
		_value.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(value);
	}

	private void OnChangeModel()
	{
		_label.Value = _model.Label;
		_value.Value = _model.Value;
	}

	#endregion
}

}