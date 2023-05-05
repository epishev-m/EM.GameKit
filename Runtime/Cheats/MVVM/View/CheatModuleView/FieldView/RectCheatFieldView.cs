namespace EM.GameKit
{

using System.Globalization;
using TMPro;
using UnityEngine;

public sealed class RectCheatFieldView : CheatFieldView<RectFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _inputFieldX;

	[SerializeField]
	private TMP_InputField _inputFieldY;

	[SerializeField]
	private TMP_InputField _inputFieldWidth;

	[SerializeField]
	private TMP_InputField _inputFieldHeight;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.X, UpdateValueX);
		Subscribe(ViewModel.Y, UpdateValueY);
		Subscribe(ViewModel.Width, UpdateValueWidth);
		Subscribe(ViewModel.Height, UpdateValueHeight);
		Subscribe(ViewModel.Label, UpdateLabel);
		Subscribe(_inputFieldX.onValueChanged, SetValueX);
		Subscribe(_inputFieldY.onValueChanged, SetValueY);
		Subscribe(_inputFieldWidth.onValueChanged, SetValueWidth);
		Subscribe(_inputFieldHeight.onValueChanged, SetValueHeight);
	}

	#endregion

	#region RectCheatFieldView

	private void UpdateValueX(float value)
	{
		_inputFieldX.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateValueY(float value)
	{
		_inputFieldY.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateValueWidth(float value)
	{
		_inputFieldWidth.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateValueHeight(float value)
	{
		_inputFieldHeight.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	private void SetValueX(string value)
	{
		if (float.TryParse(value, out var floatValue))
		{
			ViewModel.SetX(floatValue);
		}
	}

	private void SetValueY(string value)
	{
		if (float.TryParse(value, out var floatValue))
		{
			ViewModel.SetY(floatValue);
		}
	}

	private void SetValueWidth(string value)
	{
		if (float.TryParse(value, out var floatValue))
		{
			ViewModel.SetWidth(floatValue);
		}
	}

	private void SetValueHeight(string value)
	{
		if (float.TryParse(value, out var floatValue))
		{
			ViewModel.SetHeight(floatValue);
		}
	}

	#endregion
}

}