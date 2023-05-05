namespace EM.GameKit
{

using System.Collections.Generic;
using Foundation;
using TMPro;
using UnityEngine;

public sealed class CheatModuleView : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private Transform _container;

	private readonly List<ICheatFieldView> _fieldViews = new();

	private CheatsView _view;

	private ICheatsViewModel _viewModel;

	private FieldViewPool _fieldViewPool;

	#region CheatView

	public string Name => _title.text;

	public void Initialize(string cheat,
		CheatsView view,
		ICheatsViewModel viewModel,
		FieldViewPool fieldViewPool)
	{
		Requires.NotNullParam(view, nameof(view));
		Requires.NotNullParam(viewModel, nameof(viewModel));
		Requires.NotNullParam(fieldViewPool, nameof(fieldViewPool));

		_title.text = cheat;
		_view = view;
		_viewModel = viewModel;
		_fieldViewPool = fieldViewPool;

		CreateFields();
	}

	public void Release()
	{
		foreach (var view in _fieldViews)
		{
			_fieldViewPool.PutObject(view);
			view.Release();
		}

		_fieldViews.Clear();
	}

	public void SetVisibleInfo(bool value)
	{
		foreach (var view in _fieldViews)
		{
			if (view is InfoCheatFieldView)
			{
				view.SetVisible(value);
			}
		}
	}

	private void CreateFields()
	{
		var fieldViewModels = _viewModel.GetFieldViewModelsByName(Name);

		foreach (var fieldViewModel in fieldViewModels)
		{
			var result = _fieldViewPool.GetObject(fieldViewModel, _container);

			if (result.Failure)
			{
				continue;
			}

			var view = result.Data;
			view.Initialize(_view, fieldViewModel);
			_fieldViews.Add(view);
		}
	}

	#endregion
}

}