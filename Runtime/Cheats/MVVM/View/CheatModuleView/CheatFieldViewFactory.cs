namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class CheatFieldViewFactory
{
	private readonly CheatFieldViewPrefabs _prefabs;

	#region CheatFieldViewFactory

	public CheatFieldViewFactory(CheatFieldViewPrefabs prefabs)
	{
		_prefabs = prefabs;
	}

	public Result<ICheatFieldView> Create(IFieldViewModel viewModel,
		Transform parent)
	{
		Requires.NotNullParam(viewModel, nameof(viewModel));
		Requires.NotNullParam(parent, nameof(parent));

		ICheatFieldView cheatFieldView = viewModel switch
		{
			InfoFieldViewModel => CreateView(_prefabs.InfoCheatFieldViewPrefab, parent),
			BoolFieldViewModel => CreateView(_prefabs.BoolCheatFieldViewPrefab, parent),
			IntFieldViewModel => CreateView(_prefabs.IntCheatFieldView, parent),
			LongFieldViewModel => CreateView(_prefabs.LongCheatFieldView, parent),
			FloatFieldViewModel => CreateView(_prefabs.FloatCheatFieldView, parent),
			DoubleFieldViewModel => CreateView(_prefabs.DoubleCheatFieldView, parent),
			TextFieldViewModel => CreateView(_prefabs.TextCheatFieldView, parent),
			Vector2FieldViewModel => CreateView(_prefabs.Vector2CheatFieldView, parent),
			Vector3FieldViewModel => CreateView(_prefabs.Vector3CheatFieldView, parent),
			Vector4FieldViewModel => CreateView(_prefabs.Vector4CheatFieldView, parent),
			RectFieldViewModel => CreateView(_prefabs.RectCheatFieldView, parent),
			SliderFieldViewModel => CreateView(_prefabs.SliderCheatFieldView, parent),
			IntSliderFieldViewModel => CreateView(_prefabs.IntSliderCheatFieldView, parent),
			MinMaxSliderFieldViewModel => CreateView(_prefabs.MinMaxSliderCheatFieldView, parent),
			IntMinMaxSliderFieldViewModel => CreateView(_prefabs.IntMinMaxSliderCheatFieldView, parent),
			StringDropdownFieldViewModel => CreateView(_prefabs.StringDropdownFieldView, parent),
			ButtonFieldViewModel => CreateView(_prefabs.ButtonCheatFieldView, parent),
			Button2FieldViewModel => CreateView(_prefabs.Button2CheatFieldView, parent),
			Button3FieldViewModel => CreateView(_prefabs.Button3CheatFieldView, parent),
			_ => null
		};

		if (cheatFieldView == null)
		{
			return new ErrorResult<ICheatFieldView>($"Type {viewModel.GetType()} not supported");
		}

		return new SuccessResult<ICheatFieldView>(cheatFieldView);
	}

	private static ICheatFieldView CreateView<T>(T prefab,
		Transform parent)
		where T : MonoBehaviour, ICheatFieldView
	{
		var view = Object.Instantiate(prefab, parent, true);
		view.transform.localScale = Vector3.one;

		return view;
	}

	#endregion
}

}