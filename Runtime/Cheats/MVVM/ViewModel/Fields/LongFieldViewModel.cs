namespace EM.GameKit
{

using Foundation;

public sealed class LongFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<long> _value = new();

	private readonly ObservableField<string> _label = new();

	private readonly LongCheatFieldModel _model;

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

	#region LongFieldViewModel

	public LongFieldViewModel(LongCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<long> Value => _value;

	public IObservableField<string> Label => _label;

	public void SetValue(long value)
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