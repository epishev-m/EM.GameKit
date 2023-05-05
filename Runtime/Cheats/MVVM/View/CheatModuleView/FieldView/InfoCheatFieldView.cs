namespace EM.GameKit
{

using TMPro;
using UnityEngine;

public sealed class InfoCheatFieldView : CheatFieldView<InfoFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _infoText;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.Info, UpdateInfo);
	}

	#endregion

	#region InfoCheatFieldView

	private void UpdateInfo(string info)
	{
		_infoText.text = info;
	}

	#endregion
}

}