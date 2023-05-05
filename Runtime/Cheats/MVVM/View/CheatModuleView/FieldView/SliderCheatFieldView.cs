namespace EM.GameKit
{

using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class SliderCheatFieldView : CheatFieldView<SliderFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private Slider _slider;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.Value, UpdateValue);
		Subscribe(_inputField.onValueChanged, SetValue);
		Subscribe(_slider.onValueChanged, SetValue);

		_label.text = ViewModel.Label;
		_slider.minValue = ViewModel.MinLimit;
		_slider.maxValue = ViewModel.MaxLimit;
	}

	#endregion

	#region FloatCheatFieldView

	private void UpdateValue(float value)
	{
		_inputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
		_slider.SetValueWithoutNotify(value);
	}

	private void SetValue(string value)
	{
		if (!float.TryParse(value, out var floatValue))
		{
			return;
		}

		ViewModel.SetValue(floatValue);
		_slider.value = floatValue;
	}

	private void SetValue(float value)
	{
		ViewModel.SetValue(value);
		_inputField.text = value.ToString(CultureInfo.CurrentUICulture);
	}

	#endregion
}

}