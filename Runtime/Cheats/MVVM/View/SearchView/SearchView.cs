namespace EM.GameKit
{

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SearchView : MonoBehaviour
{
	[SerializeField]
	protected TMP_InputField _inputField;

	[SerializeField]
	private Button _clearButton;

	#region MonoBehaviour

	private void OnEnable()
	{
		_clearButton.onClick.AddListener(Clear);
	}

	private void OnDisable()
	{
		_clearButton.onClick.RemoveAllListeners();
	}

	#endregion

	#region SearchView

	public abstract void Initialize(ICheatsViewModel viewModel);

	public void Release()
	{
		_inputField.onValueChanged.RemoveAllListeners();
	}

	private void Clear()
	{
		_inputField.text = string.Empty;
	}

	#endregion
}

}