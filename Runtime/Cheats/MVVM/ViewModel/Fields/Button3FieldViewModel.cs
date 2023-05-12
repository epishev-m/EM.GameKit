namespace EM.GameKit
{

using Foundation;

public sealed class Button3FieldViewModel : IFieldViewModel
{
	private ObservableField<string> _label1 = new();

	private ObservableField<string> _label2 = new();

	private ObservableField<string> _label3 = new();

	private readonly Button3CheatFieldModel _model;

	#region IFieldViewModel

	void IFieldViewModel.Initialize()
	{
	}

	void IFieldViewModel.Release()
	{
	}

	void IFieldViewModel.UpdateAllRxProperties()
	{
		_label1.SetValue(_model.Label1);
		_label2.SetValue(_model.Label2);
		_label3.SetValue(_model.Label3);
	}

	#endregion

	#region Button3FieldViewModel

	public Button3FieldViewModel(Button3CheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<string> Label1 => _label1;

	public IObservableField<string> Label2 => _label2;

	public IObservableField<string> Label3 => _label2;

	public void Execute1()
	{
		_model.Action1?.Invoke();
	}

	public void Execute2()
	{
		_model.Action2?.Invoke();
	}

	public void Execute3()
	{
		_model.Action3?.Invoke();
	}

	#endregion
}

}