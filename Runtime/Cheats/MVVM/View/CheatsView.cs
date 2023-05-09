namespace EM.GameKit
{

using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(CheatsView), LifeTime.Local)]
public sealed class CheatsView : View<ICheatsViewModel>
{
	[Header(nameof(CheatsView))]

	[SerializeField]
	private float _groupsWidth;

	[SerializeField]
	private bool _hideCheats;

	[SerializeField]
	private Button _closeButton;

	[SerializeField]
	private GroupModuleViewContainer _groupModuleViewContainer;

	[SerializeField]
	private CheatModuleViewContainer _cheatModuleViewContainer;

	[SerializeField]
	private Button _showGroupsButton;

	[SerializeField]
	private Button _hideGroupsButton;

	#region View

	protected override void OnInitialize()
	{
		base.OnInitialize();

		ViewModel.VisibleGroups.Subscribe(_groupModuleViewContainer.SetVisibleGroups, CtsInstance);
		ViewModel.EnableGroups.Subscribe(_groupModuleViewContainer.SetEnableGroups, CtsInstance);
		ViewModel.VisibleCheats.Subscribe(_cheatModuleViewContainer.SetVisibleCheats, CtsInstance);
		_showGroupsButton.Subscribe(ShowGroups, CtsInstance);
		_hideGroupsButton.Subscribe(HideGroups, CtsInstance);
		_closeButton.Subscribe(ViewModel.Close, CtsInstance);

		_groupModuleViewContainer.Initialize(ViewModel);
		_cheatModuleViewContainer.Initialize(ViewModel);

		ViewModel.UpdateAll();
		ShowGroups();
	}

	protected override void OnRelease()
	{
		base.OnRelease();

		_cheatModuleViewContainer.Release();
		_groupModuleViewContainer.Release();
	}

	#endregion

	#region CheatsView

	private void ShowGroups()
	{
		ShowGroupsButtonSetActive(true);
		_groupModuleViewContainer.Show(_groupsWidth);
		_cheatModuleViewContainer.Hide(_groupsWidth, _hideCheats);
	}

	private void HideGroups()
	{
		ShowGroupsButtonSetActive(false);
		_groupModuleViewContainer.Hide();
		_cheatModuleViewContainer.Show();
	}

	private void ShowGroupsButtonSetActive(bool value)
	{
		_showGroupsButton.gameObject.SetActive(!value);
		_hideGroupsButton.gameObject.SetActive(value);
	}

	#endregion
}

}