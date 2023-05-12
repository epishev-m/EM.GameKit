namespace EM.GameKit
{

using TMPro;
using UI;
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
		this.Subscribe(ViewModel.Value, UpdateValue, CtsInstance);
		this.Subscribe(ViewModel.Label, UpdateLabel, CtsInstance);
		this.Subscribe(_inputField, SetValue, CtsInstance);
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