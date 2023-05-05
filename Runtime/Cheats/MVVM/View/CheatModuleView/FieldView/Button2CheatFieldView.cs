namespace EM.GameKit
{

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class Button2CheatFieldView : CheatFieldView<Button2FieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label1;

	[SerializeField]
	private Button _button1;

	[SerializeField]
	private TextMeshProUGUI _label2;

	[SerializeField]
	private Button _button2;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.Label1, UpdateLabel1);
		Subscribe(_button1.onClick, ViewModel.Execute1);
		Subscribe(ViewModel.Label2, UpdateLabel2);
		Subscribe(_button2.onClick, ViewModel.Execute2);
	}

	#endregion

	#region Button2CheatFieldView

	private void UpdateLabel1(string value)
	{
		_label1.text = value;
	}

	private void UpdateLabel2(string value)
	{
		_label2.text = value;
	}

	#endregion

}

}