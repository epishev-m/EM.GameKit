namespace EM.GameKit
{

using Foundation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class GroupModuleView : MonoBehaviour
{
	[SerializeField]
	private Toggle _toggle;

	[SerializeField]
	private TMP_Text _label;

	#region GroupModuleView

	public string Name => _label.text;

	public void Initialize(string label,
		ICheatsViewModel viewModel)
	{
		Requires.NotNullParam(viewModel, nameof(viewModel));

		_label.text = label;
		_toggle.onValueChanged.AddListener(value => viewModel.SetEnableGroupByName(Name, value));
	}

	public void Release()
	{
		_toggle.onValueChanged.RemoveAllListeners();
	}

	public void Disable()
	{
		_toggle.SetIsOnWithoutNotify(false);
	}

	public void Enable()
	{
		_toggle.SetIsOnWithoutNotify(true);
	}

	#endregion
}

}