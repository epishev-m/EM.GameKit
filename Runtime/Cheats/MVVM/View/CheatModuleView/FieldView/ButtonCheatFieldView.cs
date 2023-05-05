namespace EM.GameKit
{

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ButtonCheatFieldView : CheatFieldView<ButtonFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private Button _button;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.Label, UpdateLabel);
		Subscribe(_button.onClick, ViewModel.Execute);
	}

	#endregion

	#region ButtonCheatFieldView

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	#endregion

}

}