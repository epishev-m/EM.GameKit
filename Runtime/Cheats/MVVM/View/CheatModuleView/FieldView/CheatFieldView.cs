namespace EM.GameKit
{

using System;
using System.Threading;
using Foundation;
using UnityEngine;
using UnityEngine.Events;

public abstract class CheatFieldView<T> : MonoBehaviour,
	ICheatFieldView
	where T : IFieldViewModel
{
	private IFieldViewModel _viewModel;

	protected CancellationTokenSource CtsInstance;

	#region ICheatFieldView

	public void Initialize(IFieldViewModel viewModel)
	{
		Requires.NotNullParam(viewModel, nameof(viewModel));

		CtsInstance = new CancellationTokenSource();
		_viewModel = viewModel;
		_viewModel?.Initialize();
		OnInitialize();
		_viewModel?.UpdateAllRxProperties();
	}

	public virtual void Release()
	{
		OnRelease();
		CtsInstance.Cancel();
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

	#endregion
}

}