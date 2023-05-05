namespace EM.GameKit
{

using TMPro;
using UnityEngine;

public sealed class TextCheatFieldView : CheatFieldView<TextFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _inputField;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.Value, UpdateValue);
		Subscribe(ViewModel.Label, UpdateLabel);
		Subscribe(_inputField.onValueChanged, SetValue);
	}

	#endregion

	#region TextCheatFieldView

	private void UpdateValue(string value)
	{
		_inputField.SetTextWithoutNotify(value);
	}

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	private void SetValue(string value)
	{
		ViewModel.SetValue(value);
	}

	#endregion
}

}