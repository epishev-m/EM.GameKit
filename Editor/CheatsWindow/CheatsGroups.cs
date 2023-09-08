using System;
using System.Collections.Generic;
using System.Linq;
using EM.Assistant.Editor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace EM.GameKit.Editor
{

public sealed class CheatsGroups : VisualElement
{
	private readonly IEnumerable<string> _groups;

	private Foldout _foldout;

	private VisualElement _buttonsPanel;

	private VisualElement _searchPanel;

	private VisualElement _groupsPanel;

	private Dictionary<string, Toggle> _togglesGroups = new();

	public event Action OnChanged;

	#region CheatsGroups

	public CheatsGroups(IEnumerable<string> groups)
	{
		_groups = groups;
		Initialize();
		Compose();
	}

	public IEnumerable<string> GetActiveGroups()
	{
		var resultList = _togglesGroups
			.Where(pair => pair.Value.value)
			.Select(pair => pair.Key)
			.ToList();

		return resultList;
	}

	private void Initialize()
	{
		CreateFoldout();
		CreateButtons();
		CreateToolbarSearch();
		CreateGroups();
	}

	private void Compose()
	{
		Add(_foldout
			.AddChild(_buttonsPanel)
			.AddChild(_searchPanel)
			.AddChild(_groupsPanel));
	}

	private void CreateFoldout()
	{
		_foldout = new Foldout()
			.SetStylePadding(5)
			.SetStyleMargin(5)
			.SetText("Cheats Groups")
			.SetStyleBorderWidth(1)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleBorderColor(Color.gray)
			.SetStyleFlexGrow(1);
	}

	private void CreateButtons()
	{
		var buttonSelect = new Button(OnSelectAllButtonClicked)
			.SetText("Select All")
			.SetStyleFlexBasisPercent(50);

		var buttonCreate = new Button(OnDeselectAllButtonClicked)
			.SetText("Deselect All")
			.SetStyleFlexBasisPercent(50);

		_buttonsPanel = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMinHeight(22)
			.AddChild(buttonSelect)
			.AddChild(buttonCreate);
	}

	private void CreateToolbarSearch()
	{
		var toolbarSearch = new ToolbarSearchField()
			.SetStyleFlexBasisPercent(100)
			.AddValueChangedCallback<ToolbarSearchField, string>(OnToolbarSearchValueChanged);

		_searchPanel = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMinHeight(22)
			.SetStyleMargin(0, 0, 5, 5)
			.AddChild(toolbarSearch);
	}

	private void CreateGroups()
	{
		_groupsPanel = new VisualElement();

		foreach (var group in _groups)
		{
			var toggle = new Toggle(group)
			{
				value = true
			};
			toggle.AddValueChangedCallback<Toggle, bool>(_ => OnChanged?.Invoke());
			_groupsPanel.Add(toggle);
			_togglesGroups.Add(group, toggle);
		}
	}

	private void OnSelectAllButtonClicked()
	{
		foreach (var visualElement in _groupsPanel.Children())
		{
			if (visualElement is Toggle toggle)
			{
				toggle.value = true;
			}
		}
	}

	private void OnDeselectAllButtonClicked()
	{
		foreach (var visualElement in _groupsPanel.Children())
		{
			if (visualElement is Toggle toggle)
			{
				toggle.value = false;
			}
		}
	}

	private void OnToolbarSearchValueChanged(string value)
	{
		var filter = value.ToLower();

		foreach (var group in _togglesGroups)
		{
			if (group.Value.parent != null)
			{
				_groupsPanel.Remove(group.Value);
			}
		}

		foreach (var group in _togglesGroups.Where(group => group.Key.ToLower().Contains(filter)))
		{
			_groupsPanel.Add(group.Value);
		}
	}

	#endregion
}

}