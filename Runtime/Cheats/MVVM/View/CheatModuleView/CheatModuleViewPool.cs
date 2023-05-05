namespace EM.GameKit
{

using Foundation;

public sealed class CheatModuleViewPool : PoolFactory<CheatModuleView>
{
	#region PoolFactory

	public override Result<CheatModuleView> GetObject()
	{
		var result = base.GetObject();

		if (result.Failure)
		{
			return result;
		}

		var cheatView = result.Data;
		cheatView.gameObject.SetActive(true);
		cheatView.transform.SetAsLastSibling();

		return result;
	}

	public override Result PutObject(CheatModuleView cheatModuleView)
	{
		cheatModuleView.gameObject.SetActive(false);

		return base.PutObject(cheatModuleView);
	}

	#endregion

	#region CheatViewPool

	public CheatModuleViewPool(IFactory<CheatModuleView> factory) : base(factory)
	{
	}

	#endregion
}

}