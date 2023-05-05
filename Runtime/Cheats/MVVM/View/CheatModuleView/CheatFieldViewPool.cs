namespace EM.GameKit
{

using System;
using System.Collections.Generic;
using Foundation;
using UnityEngine;

public sealed class FieldViewPool
{
	private readonly Transform _root;

	private readonly CheatFieldViewFactory _factory;

	private readonly Dictionary<Type, Stack<ICheatFieldView>> _pools = new();

	#region FieldViewPool

	public FieldViewPool(Transform root,
		CheatFieldViewFactory factory)
	{
		_root = root;
		_factory = factory;
	}

	public Result<ICheatFieldView> GetObject(IFieldViewModel viewModel,
		Transform parent)
	{
		Requires.NotNullParam(viewModel, nameof(viewModel));
		Requires.NotNullParam(parent, nameof(parent));

		if (!_pools.TryGetValue(viewModel.GetType(), out var fieldViews))
		{
			return _factory.Create(viewModel, parent);
		}

		if (fieldViews.Count <= 0)
		{
			return _factory.Create(viewModel, parent);
		}

		var fieldView = fieldViews.Pop();
		fieldView.SetParent(parent);
		fieldView.SetVisible(true);

		return new SuccessResult<ICheatFieldView>(fieldView);
	}

	public Result PutObject(ICheatFieldView cheatFieldView)
	{
		Requires.NotNullParam(cheatFieldView, nameof(cheatFieldView));

		var type = cheatFieldView.GetViewModelType();

		if (!_pools.TryGetValue(type, out var stack))
		{
			stack = new Stack<ICheatFieldView>();
			_pools.Add(type, stack);
		}

		cheatFieldView.SetParent(_root);
		cheatFieldView.SetVisible(false);
		stack.Push(cheatFieldView);

		return new SuccessResult();
	}

	#endregion
}

}