namespace EM.GameKit
{

using System;
using Foundation;
using UI;
using UnityEngine;
using UnityEngine.UI;

[Asset(nameof(InternetConnectionView), LifeTime.Local)]
public sealed class InternetConnectionView : View<IInternetConnectionViewModel>,
	IDisposable
{
	[Header(nameof(InternetConnectionView))]

	[SerializeField]
	private Button _restartButton;

	#region IDisposable

	public void Dispose()
	{
		_restartButton.onClick.RemoveAllListeners();
	}

	#endregion

	#region PanelView

	protected override void OnInitialize()
	{
		_restartButton.onClick.AddListener(ViewModel.Restart);
	}

	#endregion
}

}