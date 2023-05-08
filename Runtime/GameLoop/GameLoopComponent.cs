namespace EM.GameKit
{

using System;
using UnityEngine;

public sealed class GameLoopComponent : MonoBehaviour
{
	private DateTime _lastUpdateTime = DateTime.Now;

	public event Action<float> OnTick;

	public event Action OnPause;

	public event Action OnResume;

	#region MonoBehaviour

	private void Update()
	{
		var currentUpdateTime = DateTime.Now;
		var deltaTimeSpan = currentUpdateTime - _lastUpdateTime;
		_lastUpdateTime = currentUpdateTime;
		var deltaTime = (float) deltaTimeSpan.TotalSeconds * Time.timeScale;
		OnTick?.Invoke(deltaTime);
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			OnPause?.Invoke();
		}
		else
		{
			OnResume?.Invoke();
		}
	}

	private void OnDestroy()
	{
		OnTick = null;
		OnPause = null;
		OnResume = null;
	}

	#endregion
}

}