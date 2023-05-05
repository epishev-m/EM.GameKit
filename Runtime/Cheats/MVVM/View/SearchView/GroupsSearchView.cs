namespace EM.GameKit
{

public sealed class GroupsSearchView : SearchView
{
	public override void Initialize(ICheatsViewModel viewModel)
	{
		_inputField.onValueChanged.AddListener(viewModel.SetFilterVisibleGroups);
	}
}

}