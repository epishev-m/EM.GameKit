namespace EM.GameKit
{

using TMPro;
using UI;
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
		this.Subscribe(ViewModel.Label1, UpdateLabel1, CtsInstance);
		this.Subscribe(_button1, ViewModel.Execute1, CtsInstance);
		this.Subscribe(ViewModel.Label2, UpdateLabel2, CtsInstance);
		this.Subscribe(_button2, ViewModel.Execute2, CtsInstance);
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