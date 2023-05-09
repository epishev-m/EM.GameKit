namespace EM.GameKit
{

using System.Globalization;
using TMPro;
using UI;
using UnityEngine;

public sealed class MinMaxSliderCheatFieldView : CheatFieldView<MinMaxSliderFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _minInputField;

	[SerializeField]
	private TMP_InputField _maxInputField;

	[SerializeField]
	private MinMaxSlider _minMaxSlider;

	#region MinMaxSliderCheatFieldView

	protected override void OnInitialize()
	{
		ViewModel.MinValue.Subscribe(UpdateMinValue, CtsInstance);
		ViewModel.MaxValue.Subscribe(UpdateMaxValue, CtsInstance);
		_minInputField.Subscribe(SetMinValue, CtsInstance);
		_maxInputField.Subscribe(SetMaxValue, CtsInstance);
		_minMaxSlider.OnMinValueChanged.Subscribe(SetMinValue, CtsInstance);
		_minMaxSlider.OnMaxValueChanged.Subscribe(SetMaxValue, CtsInstance);

		_label.text = ViewModel.Label;
		_minMaxSlider.MinLimit = ViewModel.MinLimit;
		_minMaxSlider.MaxLimit = ViewModel.MaxLimit;
		_minMaxSlider.MinDistance = ViewModel.MinDistance;
	}

	private void UpdateMinValue(float value)
	{
		_minInputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
		_minMaxSlider.SetMinValueWithoutNotify(value);
	}

	private void UpdateMaxValue(float value)
	{
		_maxInputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
		_minMaxSlider.SetMaxValueWithoutNotify(value);
	}

	private void SetMinValue(string value)
	{
		if (!float.TryParse(value, out var floatValue))
		{
			return;
		}

		_minMaxSlider.SetMinValueWithoutNotify(floatValue);
		_minMaxSlider.MinValue = floatValue;
	}

	private void SetMaxValue(string value)
	{
		if (!float.TryParse(value, out var floatValue))
		{
			return;
		}

		_minMaxSlider.SetMaxValueWithoutNotify(floatValue);
		_minMaxSlider.MaxValue = floatValue;
	}

	private void SetMinValue(float value)
	{
		ViewModel.SetMinValue(value);
		_minInputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void SetMaxValue(float value)
	{
		ViewModel.SetMaxValue(value);
		_maxInputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	#endregion
}

}