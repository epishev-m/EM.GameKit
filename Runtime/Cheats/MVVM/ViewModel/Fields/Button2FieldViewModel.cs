namespace EM.GameKit
{

using Foundation;

public sealed class Button2FieldViewModel : IFieldViewModel
{
	private RxProperty<string> _label1 = new();

	private RxProperty<string> _label2 = new();

	private readonly Button2CheatFieldModel _model;

	#region IFieldViewModel

	void IFieldViewModel.Initialize()
	{
	}

	void IFieldViewModel.Release()
	{
	}

	void IFieldViewModel.UpdateAllRxProperties()
	{
		_label1.Value = _model.Label1;
		_label2.Value = _model.Label2;
	}

	#endregion

	#region Button2FieldViewModel

	public Button2FieldViewModel(Button2CheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<string> Label1 => _label1;

	public IRxProperty<string> Label2 => _label2;

	public void Execute1()
	{
		_model.Action1?.Invoke();
	}

	public void Execute2()
	{
		_model.Action2?.Invoke();
	}

	#endregion
}

}