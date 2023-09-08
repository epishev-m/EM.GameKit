using System.Collections.Generic;
using System.Linq;
using EM.Assistant.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace EM.GameKit.Editor
{

public sealed class CheatsWindow : EditorWindow
{
	private readonly List<CheatsComponent> _components = new();

	private VisualElement _root;

	private HelpBox _playmodeHelpBox;

	private HelpBox _notCreatedHelpBox;

	private VisualElement _buttonsPanel;

	private VisualElement _componentsVisualElement;

	private CheatsGroups _cheatsGroups;

	private ToolbarSearchField _toolbarSearch;

	private VisualElement _searchPanel;

	private ScrollView _scrollView;

	#region EditorWindow

	private void CreateGUI()
	{
		EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
		autoRepaintOnSceneChange = true;
		Initialize();
		Compose();
	}

	#endregion

	#region CheatsWindow

	private void Initialize()
	{
		CreateHelpBox();

		if (Cheats.CheatsModel == null)
		{
			return;
		}

		CreateButtons();
		CreateToolbarSearch();
		CreateScrollView();
		CreateCheatsGroups();
		CreateComponents();
	}

	private void Compose()
	{
		_root = new VisualElement()
			.SetStylePadding(10);

		if (!Application.isPlaying)
		{
			_root.Add(_playmodeHelpBox);
		}
		else if (Cheats.CheatsModel == null)
		{
			_root.Add(_notCreatedHelpBox);
		}
		else
		{
			_root.AddChild(_scrollView
				.AddChild(_cheatsGroups)
				.AddChild(_buttonsPanel)
				.AddChild(_searchPanel)
				.AddChild(_componentsVisualElement));
		}

		rootVisualElement.Add(_root);
	}

	private void CreateHelpBox()
	{
		_playmodeHelpBox = new HelpBox("Cheats are only available in playmode!", HelpBoxMessageType.Info)
			.SetStyleMargin(10);
		_notCreatedHelpBox = new HelpBox("cheats are not created!", HelpBoxMessageType.Info)
			.SetStyleMargin(10);
	}

	private void CreateButtons()
	{
		var buttonSelect = new Button(OnShowAllButtonClicked)
			.SetText("Show All")
			.SetStyleFlexBasisPercent(50);

		var buttonCreate = new Button(OnHideAllButtonClicked)
			.SetText("Hide All")
			.SetStyleFlexBasisPercent(50);

		_buttonsPanel = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMinHeight(22)
			.SetStyleMargin(5)
			.AddChild(buttonSelect)
			.AddChild(buttonCreate);
	}

	private void CreateToolbarSearch()
	{
		_toolbarSearch = new ToolbarSearchField()
			.SetStyleFlexBasisPercent(100)
			.AddValueChangedCallback<ToolbarSearchField, string>(OnToolbarSearchValueChanged);

		_searchPanel = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMinHeight(22)
			.SetStyleMargin(0, 0, 5, 5)
			.AddChild(_toolbarSearch);
	}

	private void CreateScrollView()
	{
		_scrollView = new ScrollView()
			.SetStyleMargin(5);
	}

	private void CreateCheatsGroups()
	{
		var groups = Cheats.CheatsModel.GetGroups();
		_cheatsGroups = new CheatsGroups(groups);
		_cheatsGroups.OnChanged += OnCheatsGroupsChanged;
	}

	private void CreateComponents()
	{
		_componentsVisualElement = new VisualElement()
			.SetStyleMargin(5);
		_components.Clear();
		var components = GetWindowComponents();

		foreach (var component in components)
		{
			_componentsVisualElement.Add(component);
			_components.Add(component);
		}
	}

	private static IEnumerable<CheatsComponent> GetWindowComponents()
	{
		var resultList = new List<CheatsComponent>();
		var names = Cheats.CheatsModel.GetNames();

		foreach (var cheatName in names)
		{
			var fields = Cheats.CheatsModel.GetFieldsByName(cheatName);
			var component = new CheatsComponent(cheatName, fields);
			resultList.Add(component);
		}

		return resultList;
	}

	private void OnShowAllButtonClicked()
	{
		_components.ForEach(c => c.Show());
	}

	private void OnHideAllButtonClicked()
	{
		_components.ForEach(c => c.Hide());
	}

	private void OnToolbarSearchValueChanged(string value)
	{
		foreach (var component in _components)
		{
			SetVisibleComponent(component, false);
		}

		var components = GetActiveComponents();
		var filter = value.ToLower();

		foreach (var component in components.Where(component => component.Name.ToLower().Contains(filter)))
		{
			SetVisibleComponent(component, true);
		}
	}

	private void OnPlayModeStateChanged(PlayModeStateChange state)
	{
		if (state != PlayModeStateChange.ExitingPlayMode)
		{
			return;
		}

		_root.Clear();
		_root.Add(_playmodeHelpBox);
	}

	private void OnCheatsGroupsChanged()
	{
		var filter = _toolbarSearch.value;
		OnToolbarSearchValueChanged(filter);
	}

	private IEnumerable<CheatsComponent> GetActiveComponents()
	{
		var resultList = new List<CheatsComponent>();
		var activeGroups = _cheatsGroups.GetActiveGroups().ToArray();

		foreach (var component in _components)
		{
			var groups = Cheats.CheatsModel.GetGroupsByName(component.Name);

			if (CheckGroups(activeGroups, groups))
			{
				resultList.Add(component);
			}
		}

		return resultList;
	}

	private static bool CheckGroups(IEnumerable<string> activeGroups,
		IEnumerable<string> groups)
	{
		var activeGroupsArray = activeGroups.ToArray();

		foreach (var group in groups)
		{
			if (activeGroupsArray.Any(g => g == group))
			{
				return true;
			}
		}

		return false;
	}

	private void SetVisibleComponent(VisualElement component,
		bool visible)
	{
		if (visible)
		{
			if (component.parent == null)
			{
				_componentsVisualElement.Add(component);
			}
		}
		else
		{
			if (component.parent != null)
			{
				_componentsVisualElement.Remove(component);
			}
		}
	}

	#endregion
}

}