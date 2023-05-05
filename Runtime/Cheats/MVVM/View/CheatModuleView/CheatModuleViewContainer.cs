namespace EM.GameKit
{

using System.Collections.Generic;
using System.Linq;
using Foundation;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public sealed class CheatModuleViewContainer : MonoBehaviour
{
	[SerializeField]
	private RectTransform _rectTransform;

	[SerializeField]
	private Toggle _infoToggle;

	[SerializeField]
	private SearchView _searchView;

	[SerializeField]
	private Transform _container;

	[SerializeField]
	private CheatModuleView _cheatModuleViewPrefab;

	[SerializeField]
	private CheatFieldViewPrefabs _cheatFieldViewPrefabs;

	[SerializeField]
	private Transform _fieldViewPoolRoot;

	private readonly List<CheatModuleView> _cheatViews = new();

	private CheatsView _view;

	private ICheatsViewModel _viewModel;

	private CheatModuleViewPool _cheatModuleViewPool;

	private FieldViewPool _fieldViewPool;

	#region MonoBehaviour

	private void Awake()
	{
		var cheatViewFactory = new CheatModuleViewFactory(_container, _cheatModuleViewPrefab);
		_cheatModuleViewPool = new CheatModuleViewPool(cheatViewFactory);

		var fieldViewFactory = new CheatFieldViewFactory(_cheatFieldViewPrefabs);
		_fieldViewPool = new FieldViewPool(_fieldViewPoolRoot, fieldViewFactory);
	}

	private void OnEnable()
	{
		_infoToggle.onValueChanged.AddListener(SetVisibleInfo);
	}

	private void OnDisable()
	{
		_infoToggle.onValueChanged.RemoveAllListeners();
	}

	#endregion

	#region CheatsContainer

	public void Show()
	{
		_rectTransform.sizeDelta = new Vector2(-20f, 0f);
		_rectTransform.anchoredPosition = new Vector2(20f, 0f);
		_rectTransform.gameObject.SetActive(true);
	}

	public void Hide(float width, bool idHide)
	{
		_rectTransform.sizeDelta = new Vector2(-width, 0f);
		_rectTransform.anchoredPosition = new Vector2(width, 0f);

		if (idHide)
		{
			_rectTransform.gameObject.SetActive(false);
		}
	}

	public void Initialize(CheatsView view, ICheatsViewModel viewModel)
	{
		Requires.NotNullParam(view, nameof(view));
		Requires.NotNullParam(viewModel, nameof(viewModel));

		_view = view;
		_viewModel = viewModel;
		_searchView.Initialize(_viewModel);
		CreateCheats();
		UpdateInfoToggle();
	}

	public void Release()
	{
		ReleaseCheatViews();
		_searchView.Release();
		_viewModel = null;
	}

	public void SetVisibleCheats(IEnumerable<string> cheats)
	{
		foreach (var view in _cheatViews)
		{
			view.gameObject.SetActive(false);
		}

		foreach (var cheat in cheats)
		{
			var view = _cheatViews.FirstOrDefault(v => v.Name == cheat);

			if (view != null)
			{
				view.gameObject.SetActive(true);
			}
		}
	}

	private void CreateCheats()
	{
		foreach (var cheat in _viewModel.Names)
		{
			var result = _cheatModuleViewPool.GetObject();

			if (result.Failure)
			{
				continue;
			}

			var cheatView = result.Data;
			cheatView.Initialize(cheat, _view, _viewModel, _fieldViewPool);
			_cheatViews.Add(cheatView);
		}
	}

	private void UpdateInfoToggle()
	{
		_infoToggle.SetIsOnWithoutNotify(true);
		SetVisibleInfo(true);
	}

	private void ReleaseCheatViews()
	{
		foreach (var cheatView in _cheatViews)
		{
			_cheatModuleViewPool.PutObject(cheatView);
			cheatView.Release();
		}

		_cheatViews.Clear();
	}

	private void SetVisibleInfo(bool value)
	{
		foreach (var view in _cheatViews)
		{
			view.SetVisibleInfo(!value);
		}
	}

	#endregion
}

}