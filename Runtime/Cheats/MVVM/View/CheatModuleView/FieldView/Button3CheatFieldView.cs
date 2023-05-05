namespace EM.GameKit
{

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class Button3CheatFieldView : CheatFieldView<Button3FieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label1;

	[SerializeField]
	private Button _button1;

	[SerializeField]
	private TextMeshProUGUI _label2;

	[SerializeField]
	private Button _button2;

	[SerializeField]
	private TextMeshProUGUI _label3;

	[SerializeField]
	private Button _button3;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.Label1, UpdateLabel1);
		Subscribe(_button1.onClick, ViewModel.Execute1);
		Subscribe(ViewModel.Label2, UpdateLabel2);
		Subscribe(_button2.onClick, ViewModel.Execute2);
		Subscribe(ViewModel.Label3, UpdateLabel3);
		Subscribe(_button3.onClick, ViewModel.Execute3);
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

	private void UpdateLabel3(string value)
	{
		_label3.text = value;
	}

	#endregion

}

}