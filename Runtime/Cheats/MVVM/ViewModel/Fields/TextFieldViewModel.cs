namespace EM.GameKit
{

using Foundation;

public sealed class TextFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<string> _value = new();

	private readonly ObservableField<string> _label = new();

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

	public IObservableField<string> Value => _value;

	public IObservableField<string> Label => _label;

	public void SetValue(string value)
	{
		_value.SetValueWithoutNotify(value);
		_model.Value = value;
	}

	private void OnChangeModel()
	{
		_label.SetValue(_model.Label);
		_value.SetValue(_model.Value);
	}

	#endregion
}

}