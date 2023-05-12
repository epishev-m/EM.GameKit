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
		this.Subscribe(ViewModel.Value, UpdateValue, CtsInstance);
		this.Subscribe(ViewModel.Label, UpdateLabel, CtsInstance);
		this.Subscribe(_toggle, ViewModel.SetValue, CtsInstance);
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