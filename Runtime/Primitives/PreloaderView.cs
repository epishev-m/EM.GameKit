namespace EM.GameKit
{

using UnityEngine;

public sealed class PreloaderView : MonoBehaviour
{
	[SerializeField]
	private Transform _contextTransform;

	[SerializeField]
	private Transform _rotationTransform;

	[SerializeField]
	private float _rotateDuration = 0.5f;

	#region MonoBehaviour

	private void Awake()
	{
		Hide();
	}

	public void Update()
	{
		var angle = -Time.realtimeSinceStartup % _rotateDuration / _rotateDuration * 360.0f;
		_rotationTransform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	#endregion

	#region PreloaderView

	public void Show()
	{
		enabled = true;
		_contextTransform.gameObject.SetActive(true);
	}

	public void Hide()
	{
		enabled = false;
		_contextTransform.gameObject.SetActive(false);
	}

	#endregion
}

}