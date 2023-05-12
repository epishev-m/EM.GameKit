namespace EM.GameKit
{

using Foundation;

public sealed class InfoFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<string> _info = new();

	private readonly InfoCheatFieldModel _model;

	#region IFieldViewModel

	void IFieldViewModel.Initialize()
	{
	}

	void IFieldViewModel.Release()
	{
	}

	void IFieldViewModel.UpdateAllRxProperties()
	{
		_info.SetValue(_model.Info);
	}

	#endregion

	#region InfoFieldViewModel

	public InfoFieldViewModel(InfoCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<string> Info => _info;

	#endregion
}

}