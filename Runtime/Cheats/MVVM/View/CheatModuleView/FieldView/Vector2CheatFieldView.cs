namespace EM.GameKit
{

using System.Globalization;
using TMPro;
using UI;
using UnityEngine;

public sealed class Vector2CheatFieldView : CheatFieldView<Vector2FieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _inputFieldX;

	[SerializeField]
	private TMP_InputField _inputFieldY;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		ViewModel.X.Subscribe(UpdateValueX, CtsInstance);
		ViewModel.Y.Subscribe(UpdateValueY, CtsInstance);
		ViewModel.Label.Subscribe(UpdateLabel, CtsInstance);
		_inputFieldX.Subscribe(SetValueX, CtsInstance);
		_inputFieldY.Subscribe(SetValueY, CtsInstance);
	}

	#endregion

	#region Vector2FieldView

	private void UpdateValueX(float value)
	{
		_inputFieldX.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateValueY(float value)
	{
		_inputFieldY.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
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

	#endregion
}

}