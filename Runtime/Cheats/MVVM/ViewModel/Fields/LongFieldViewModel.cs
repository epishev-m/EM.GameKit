namespace EM.GameKit
{

using Foundation;

public sealed class LongFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<long> _value = new();

	private readonly RxProperty<string> _label = new();

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

	public IRxProperty<long> Value => _value;

	public IRxProperty<string> Label => _label;

	public void SetValue(long value)
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