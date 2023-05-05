namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class CheatModuleViewFactory : IFactory<CheatModuleView>
{
	private readonly Transform _parent;

	private readonly CheatModuleView _cheatModuleViewPrefab;

	#region IFactory

	public Result<CheatModuleView> Create()
	{
		var cheatView = Object.Instantiate(_cheatModuleViewPrefab, _parent, true);
		cheatView.transform.localScale = Vector3.one;

		return new SuccessResult<CheatModuleView>(cheatView);
	}

	#endregion

	#region CheatViewFactory

	public CheatModuleViewFactory(Transform parent,
		CheatModuleView cheatModuleViewPrefab)
	{
		_parent = parent;
		_cheatModuleViewPrefab = cheatModuleViewPrefab;
	}

	#endregion
}

}