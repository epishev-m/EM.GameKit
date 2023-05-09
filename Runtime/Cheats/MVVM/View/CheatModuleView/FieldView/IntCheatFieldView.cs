namespace EM.GameKit
{

using TMPro;
using UI;
using UnityEngine;

public sealed class IntCheatFieldView : CheatFieldView<IntFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _inputField;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		ViewModel.Value.Subscribe(UpdateValue, CtsInstance);
		ViewModel.Label.Subscribe(UpdateLabel, CtsInstance);
		_inputField.Subscribe(SetValue, CtsInstance);
	}

	#endregion

	#region IntCheatFieldView

	private void UpdateValue(int value)
	{
		_inputField.SetTextWithoutNotify(value.ToString());
	}

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	private void SetValue(string value)
	{
		if (int.TryParse(value, out var intValue))
		{
			ViewModel.SetValue(intValue);
		}
	}

	#endregion
}

}