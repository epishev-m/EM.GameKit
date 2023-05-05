namespace EM.GameKit
{

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class BoolCheatFieldView : CheatFieldView<BoolFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private Toggle _toggle;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.Value, UpdateValue);
		Subscribe(ViewModel.Label, UpdateLabel);
		Subscribe(_toggle.onValueChanged, ViewModel.SetValue);
	}

	#endregion

	#region IntCheatFieldView

	private void UpdateValue(bool value)
	{
		_toggle.SetIsOnWithoutNotify(value);
	}

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	#endregion
}

}