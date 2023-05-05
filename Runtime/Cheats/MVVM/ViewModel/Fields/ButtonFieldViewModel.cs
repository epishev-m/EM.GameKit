namespace EM.GameKit
{

using Foundation;

public sealed class ButtonFieldViewModel : IFieldViewModel
{
	private RxProperty<string> _label = new();

	private readonly ButtonCheatFieldModel _model;

	#region IFieldViewModel

	void IFieldViewModel.Initialize()
	{
	}

	void IFieldViewModel.Release()
	{
	}

	void IFieldViewModel.UpdateAllRxProperties()
	{
		_label.Value = _model.Label;
	}

	#endregion

	#region ButtonFieldViewModel

	public ButtonFieldViewModel(ButtonCheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<string> Label => _label;

	public void Execute()
	{
		_model.Action?.Invoke();
	}

	#endregion
}

}