namespace EM.GameKit
{

using System.Globalization;
using TMPro;
using UI;
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
		ViewModel.X.Subscribe(UpdateValueX, CtsInstance);
		ViewModel.Y.Subscribe(UpdateValueY, CtsInstance);
		ViewModel.Width.Subscribe(UpdateValueWidth, CtsInstance);
		ViewModel.Height.Subscribe(UpdateValueHeight, CtsInstance);
		ViewModel.Label.Subscribe(UpdateLabel, CtsInstance);
		_inputFieldX.Subscribe(SetValueX, CtsInstance);
		_inputFieldY.Subscribe(SetValueY, CtsInstance);
		_inputFieldWidth.Subscribe(SetValueWidth, CtsInstance);
		_inputFieldHeight.Subscribe(SetValueHeight, CtsInstance);
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