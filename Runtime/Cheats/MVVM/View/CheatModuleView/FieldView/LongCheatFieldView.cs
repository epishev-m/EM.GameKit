namespace EM.GameKit
{

using TMPro;
using UI;
using UnityEngine;

public sealed class LongCheatFieldView : CheatFieldView<LongFieldViewModel>
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

	#region IntCheatFieldView

	private void UpdateValue(long value)
	{
		_inputField.SetTextWithoutNotify(value.ToString());
	}

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	private void SetValue(string value)
	{
		if (long.TryParse(value, out var intValue))
		{
			ViewModel.SetValue(intValue);
		}
	}

	#endregion
}

}