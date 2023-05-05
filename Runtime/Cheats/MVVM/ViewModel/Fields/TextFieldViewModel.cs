namespace EM.GameKit
{

using Foundation;

public sealed class TextFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<string> _value = new();

	private readonly RxProperty<string> _label = new();

	private readonly TextCheatFieldModel _model;

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

	#region TextFieldViewModel

	public TextFieldViewModel(TextCheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<string> Value => _value;

	public IRxProperty<string> Label => _label;

	public void SetValue(string value)
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