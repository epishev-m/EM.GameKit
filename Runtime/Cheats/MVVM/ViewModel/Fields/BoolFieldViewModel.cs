namespace EM.GameKit
{

using Foundation;

public sealed class BoolFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<bool> _value = new();

	private readonly ObservableField<string> _label = new();

	private readonly BoolCheatFieldModel _model;

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

	#region IntFieldViewModel

	public BoolFieldViewModel(BoolCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<bool> Value => _value;

	public IObservableField<string> Label => _label;

	public void SetValue(bool value)
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