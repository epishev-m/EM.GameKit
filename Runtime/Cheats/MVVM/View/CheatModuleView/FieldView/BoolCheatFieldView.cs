namespace EM.GameKit
{

using TMPro;
using UI;
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
		ViewModel.Value.Subscribe(UpdateValue, CtsInstance);
		ViewModel.Label.Subscribe(UpdateLabel, CtsInstance);
		_toggle.Subscribe(ViewModel.SetValue, CtsInstance);
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