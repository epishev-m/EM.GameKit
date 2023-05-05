namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class GroupModuleViewFactory : IFactory<GroupModuleView>
{
	private readonly Transform _parent;

	private readonly GroupModuleView _groupModuleViewPrefab;

	#region IFactory
	
	public Result<GroupModuleView> Create()
	{
		var groupView = Object.Instantiate(_groupModuleViewPrefab, _parent, true);
		groupView.transform.localScale = Vector3.one;

		return new SuccessResult<GroupModuleView>(groupView);
	}

	#endregion

	#region GroupModuleViewFactory

	public GroupModuleViewFactory(Transform parent,
		GroupModuleView groupModuleViewPrefab)
	{
		_parent = parent;
		_groupModuleViewPrefab = groupModuleViewPrefab;
	}

	#endregion
}

}