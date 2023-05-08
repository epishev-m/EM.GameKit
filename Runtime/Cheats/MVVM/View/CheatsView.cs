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

		Subscribe(ViewModel.VisibleGroups, _groupModuleViewContainer.SetVisibleGroups);
		Subscribe(ViewModel.EnableGroups, _groupModuleViewContainer.SetEnableGroups);
		Subscribe(ViewModel.VisibleCheats, _cheatModuleViewContainer.SetVisibleCheats);
		Subscribe(_showGroupsButton.onClick, ShowGroups);
		Subscribe(_hideGroupsButton.onClick, HideGroups);
		Subscribe(_closeButton.onClick, ViewModel.Close);

		_groupModuleViewContainer.Initialize(ViewModel);
		_cheatModuleViewContainer.Initialize(this, ViewModel);

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