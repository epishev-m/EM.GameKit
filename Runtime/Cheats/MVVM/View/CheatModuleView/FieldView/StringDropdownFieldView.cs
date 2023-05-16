namespace EM.GameKit
{

using UI;
using System.Linq;
using TMPro;
using UnityEngine;

public sealed class StringDropdownFieldView : CheatFieldView<StringDropdownFieldViewModel>
{
	[SerializeField]
	private TMP_Dropdown _dropdown;
	
	#region CheatFieldView

	protected override void OnInitialize()
	{
		_dropdown.AddOptions(ViewModel.Options.ToList());

		this.Subscribe(ViewModel.Index, SetIndex, CtsInstance);
		this.Subscribe(_dropdown, ViewModel.SetIndex, CtsInstance);
	}

	#endregion

	#region StringDropdownFieldView

	private void SetIndex(int index)
	{
		_dropdown.value = index;
	}

	#endregion
}

}