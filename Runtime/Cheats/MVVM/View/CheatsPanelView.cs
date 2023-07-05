namespace EM.GameKit
{

using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[ViewAsset(nameof(CheatsPanelView), LifeTime.Local)]
public sealed class CheatsPanelView : PanelView<ICheatsViewModel>
{
	[Header(nameof(CheatsPanelView))]

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
		InitializeModules();
		Connect();
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

	private void InitializeModules()
	{
		_groupModuleViewContainer.Initialize(ViewModel);
		_cheatModuleViewContainer.Initialize(ViewModel);
	}

	private void Connect()
	{
		this.Subscribe(ViewModel.VisibleGroups, _groupModuleViewContainer.SetVisibleGroups, CtsInstance);
		this.Subscribe(ViewModel.EnableGroups, _groupModuleViewContainer.SetEnableGroups, CtsInstance);
		this.Subscribe(ViewModel.VisibleCheats, _cheatModuleViewContainer.SetVisibleCheats, CtsInstance);
		this.Subscribe(_showGroupsButton, ShowGroups, CtsInstance);
		this.Subscribe(_hideGroupsButton, HideGroups, CtsInstance);
		this.Subscribe(_closeButton, ViewModel.Close, CtsInstance);
	}

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