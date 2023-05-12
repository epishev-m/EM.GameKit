namespace EM.GameKit
{

using System;
using UnityEngine;

public interface ICheatFieldView
{
	void Initialize(IFieldViewModel viewModel);
	
	void Release();

	Type GetViewModelType();

	void SetVisible(bool value);

	void SetParent(Transform parent);
}

}