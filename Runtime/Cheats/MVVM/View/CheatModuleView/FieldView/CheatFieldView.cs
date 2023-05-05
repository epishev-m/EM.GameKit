namespace EM.GameKit
{

using System;
using Foundation;
using UnityEngine;
using UnityEngine.Events;

public abstract class CheatFieldView<T> : MonoBehaviour,
	ICheatFieldView
	where T : IFieldViewModel
{
	private CheatsView _parentView;

	private IFieldViewModel _viewModel;

	#region ICheatFieldView

	public void Initialize(CheatsView parentView, IFieldViewModel viewModel)
	{
		Requires.NotNullParam(parentView, nameof(parentView));
		Requires.NotNullParam(viewModel, nameof(viewModel));

		_parentView = parentView;
		_viewModel = viewModel;
		_viewModel?.Initialize();
		OnInitialize();
		_viewModel?.UpdateAllRxProperties();
	}

	public virtual void Release()
	{
		OnRelease();
		_viewModel.Release();
		_viewModel = null;
	}

	Type ICheatFieldView.GetViewModelType()
	{
		return typeof(T);
	}

	void ICheatFieldView.SetVisible(bool value)
	{
		gameObject.SetActive(value);
	}

	void ICheatFieldView.SetParent(Transform parent)
	{
		transform.SetParent(parent, true);
	}

	#endregion

	#region CheatFieldView

	protected T ViewModel => (T) _viewModel;

	protected abstract void OnInitialize();

	protected virtual void OnRelease()
	{
	}

	protected void Subscribe<TValue>(IRxProperty<TValue> property,
		Action<TValue> handler)
	{
		_parentView.Subscribe(property, handler);
	}

	protected void Subscribe(UnityEvent unityEvent,
		Action handler)
	{
		_parentView.Subscribe(unityEvent, handler);
	}

	protected void Subscribe<TValue>(UnityEvent<TValue> unityEvent,
		Action<TValue> handler)
	{
		_parentView.Subscribe(unityEvent, handler);
	}

	#endregion
}

}