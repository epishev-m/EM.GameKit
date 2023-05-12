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
		this.Subscribe(ViewModel.Label1, UpdateLabel1, CtsInstance);
		this.Subscribe(_button1, ViewModel.Execute1, CtsInstance);
		this.Subscribe(ViewModel.Label2, UpdateLabel2, CtsInstance);
		this.Subscribe(_button2, ViewModel.Execute2, CtsInstance);
		this.Subscribe(ViewModel.Label3, UpdateLabel3, CtsInstance);
		this.Subscribe(_button3, ViewModel.Execute3, CtsInstance);
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