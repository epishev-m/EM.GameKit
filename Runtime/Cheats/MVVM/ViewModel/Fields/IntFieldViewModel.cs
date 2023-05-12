namespace EM.GameKit
{

using Foundation;

public sealed class IntFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<int> _value = new();

	private readonly ObservableField<string> _label = new();

	private readonly IntCheatFieldModel _model;

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

	public IntFieldViewModel(IntCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<int> Value => _value;

	public IObservableField<string> Label => _label;

	public void SetValue(int value)
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