namespace EM.GameKit
{

using Foundation;

public sealed class FloatFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<float> _value = new();

	private readonly ObservableField<string> _label = new();

	private readonly FloatCheatFieldModel _model;

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

	#region FloatFieldViewModel

	public FloatFieldViewModel(FloatCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<float> Value => _value;

	public IObservableField<string> Label => _label;

	public void SetValue(float value)
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