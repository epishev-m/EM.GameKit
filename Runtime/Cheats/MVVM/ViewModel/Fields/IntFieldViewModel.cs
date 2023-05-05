namespace EM.GameKit
{

using Foundation;

public sealed class IntFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<int> _value = new();

	private readonly RxProperty<string> _label = new();

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

	public IRxProperty<int> Value => _value;

	public IRxProperty<string> Label => _label;

	public void SetValue(int value)
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