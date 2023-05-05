namespace EM.GameKit
{

using Foundation;

public sealed class GroupModuleViewPool : PoolFactory<GroupModuleView>
{
	#region PoolFactory

	public override Result<GroupModuleView> GetObject()
	{
		var result = base.GetObject();

		if (result.Failure)
		{
			return result;
		}

		var groupView = result.Data;
		groupView.gameObject.SetActive(true);
		groupView.transform.SetAsLastSibling();

		return result;
	}

	public override Result PutObject(GroupModuleView moduleView)
	{
		moduleView.gameObject.SetActive(false);

		return base.PutObject(moduleView);
	}

	#endregion

	#region GroupModuleViewPool

	public GroupModuleViewPool(IFactory<GroupModuleView> factory) : base(factory)
	{
	}

	#endregion
}

}