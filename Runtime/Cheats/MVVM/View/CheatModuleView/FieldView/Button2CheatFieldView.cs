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
		ViewModel.Label1.Subscribe(UpdateLabel1, CtsInstance);
		_button1.Subscribe(ViewModel.Execute1, CtsInstance);
		ViewModel.Label2.Subscribe(UpdateLabel2, CtsInstance);
		_button2.Subscribe(ViewModel.Execute2, CtsInstance);
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