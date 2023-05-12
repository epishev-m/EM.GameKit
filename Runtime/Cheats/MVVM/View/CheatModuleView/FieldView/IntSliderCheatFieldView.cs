namespace EM.GameKit
{

using System.Globalization;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public sealed class IntSliderCheatFieldView : CheatFieldView<IntSliderFieldViewModel>
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
		this.Subscribe(ViewModel.Value, UpdateValue, CtsInstance);
		this.Subscribe(_inputField, SetValue, CtsInstance);
		this.Subscribe(_slider, SetValue, CtsInstance);

		_label.text = ViewModel.Label;
		_slider.minValue = ViewModel.MinLimit;
		_slider.maxValue = ViewModel.MaxLimit;
	}

	#endregion

	#region FloatCheatFieldView

	private void UpdateValue(int value)
	{
		_inputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
		_slider.SetValueWithoutNotify(value);
	}

	private void SetValue(string value)
	{
		if (!int.TryParse(value, out var intValue))
		{
			return;
		}

		ViewModel.SetValue(intValue);
		_slider.value = intValue;
	}

	private void SetValue(float value)
	{
		ViewModel.SetValue((int) value);
		_inputField.text = value.ToString(CultureInfo.CurrentUICulture);
	}

	#endregion
}

}