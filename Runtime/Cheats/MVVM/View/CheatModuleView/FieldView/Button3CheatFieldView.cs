namespace EM.GameKit
{

using TMPro;
using UI;
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
		ViewModel.Label1.Subscribe(UpdateLabel1, CtsInstance);
		_button1.Subscribe(ViewModel.Execute1, CtsInstance);
		ViewModel.Label2.Subscribe(UpdateLabel2, CtsInstance);
		_button2.Subscribe(ViewModel.Execute2, CtsInstance);
		ViewModel.Label3.Subscribe(UpdateLabel3, CtsInstance);
		_button3.Subscribe(ViewModel.Execute3, CtsInstance);
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