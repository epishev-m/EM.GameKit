namespace EM.GameKit
{

using TMPro;
using UI;
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
		this.Subscribe(ViewModel.Label, UpdateLabel, CtsInstance);
		this.Subscribe(_button, ViewModel.Execute, CtsInstance);
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