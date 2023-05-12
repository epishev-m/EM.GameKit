namespace EM.GameKit
{

using System.Globalization;
using TMPro;
using UI;
using UnityEngine;

public sealed class DoubleCheatFieldView : CheatFieldView<DoubleFieldViewModel>
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

	#region FloatCheatFieldView

	private void UpdateValue(double value)
	{
		_inputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	private void SetValue(string value)
	{
		if (double.TryParse(value, out var doubleValue))
		{
			ViewModel.SetValue(doubleValue);
		}
	}

	#endregion
}

}