namespace EM.GameKit
{

public sealed class CheatsSearchView : SearchView
{
	public override void Initialize(ICheatsViewModel viewModel)
	{
		_inputField.onValueChanged.AddListener(viewModel.SetFilterVisibleCheats);
	}
}

}