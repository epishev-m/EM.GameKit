namespace EM.GameKit
{

using UnityEngine;

public sealed class CheatTest : ICheat
{
	private readonly BoolCheatFieldModel _boolCheatFieldModel = new("Bool");

	private readonly IntCheatFieldModel _intCheatFieldModel = new("Int");

	private readonly LongCheatFieldModel _longCheatFieldModel = new("Long");

	private readonly FloatCheatFieldModel _floatCheatFieldModel = new("Float");

	private readonly DoubleCheatFieldModel _doubleCheatFieldModel = new("Double");

	private readonly TextCheatFieldModel _textCheatFieldModel = new("Text");

	private readonly Vector2CheatFieldModel _vector2CheatFieldModel = new("Vector2");

	private readonly Vector3CheatFieldModel _vector3CheatFieldModel = new("Vector3");

	private readonly Vector4CheatFieldModel _vector4CheatFieldModel = new("Vector4");

	private readonly RectCheatFieldModel _rectCheatFieldModel = new("Rect");

	private readonly SliderCheatFieldModel _sliderCheatFieldModel = new("Slider", 0f, 10f);

	private readonly IntSliderCheatFieldModel _intSliderCheatFieldModel = new("IntSlider", 0, 50);

	private readonly MinMaxSliderCheatFieldModel _minMaxSliderCheatFieldModel = new("MinMaxSlider", 0f, 1f, 0.1f);

	private readonly IntMinMaxSliderCheatFieldModel _intMinMaxSliderCheatFieldModel = new("IntMinMaxSlider", 1, 10, 1);

	private readonly StringDropdownCheatFieldModel _stringDropdownCheatFieldModel = new("StringDropdown", new[] {"Uno", "Dos", "Tres"});

	#region ICheat

	public void Registration(ICheatBinder cheatBinder)
	{
		cheatBinder.Bind("Cheat Bool")
			.InGlobal()
			.SetGroups("base", "Bool")
			.AddInfo("Demonstration Bool!")
			.AddField(_boolCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_boolCheatFieldModel.Value));

		cheatBinder.Bind("Cheat Int")
			.InGlobal()
			.SetGroups("base", "Int")
			.AddInfo("Demonstration Int!")
			.AddField(_intCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_intCheatFieldModel.Value));

		cheatBinder.Bind("Cheat Long")
			.InGlobal()
			.SetGroups("base", "Int")
			.AddInfo("Demonstration Long!")
			.AddField(_longCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_longCheatFieldModel.Value));

		cheatBinder.Bind("Cheat Float")
			.InGlobal()
			.SetGroups("base", "Singl")
			.AddInfo("Demonstration Float!")
			.AddField(_floatCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_floatCheatFieldModel.Value));

		cheatBinder.Bind("Cheat Double")
			.InGlobal()
			.SetGroups("base", "Singl")
			.AddInfo("Demonstration Double!")
			.AddField(_doubleCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_doubleCheatFieldModel.Value));

		cheatBinder.Bind("Cheat Text")
			.InGlobal()
			.SetGroups("base")
			.AddInfo("Demonstration Text!")
			.AddField(_textCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_textCheatFieldModel.Value));

		cheatBinder.Bind("Cheat Vector2")
			.InGlobal()
			.SetGroups("Combined", "Vector")
			.AddInfo("Demonstration Vector2!")
			.AddField(_vector2CheatFieldModel)
			.AddButton("Log", () => Debug.Log(_vector2CheatFieldModel.Value));

		cheatBinder.Bind("Cheat Vector3")
			.InGlobal()
			.SetGroups("Combined", "Vector")
			.AddInfo("Demonstration Vector3!")
			.AddField(_vector3CheatFieldModel)
			.AddButton("Log", () => Debug.Log(_vector3CheatFieldModel.Value));

		cheatBinder.Bind("Cheat Vector4")
			.InGlobal()
			.SetGroups("Combined", "Vector")
			.AddInfo("Demonstration Vector4!")
			.AddField(_vector4CheatFieldModel)
			.AddButton("Log", () => Debug.Log(_vector4CheatFieldModel.Value));

		cheatBinder.Bind("Cheat Rect")
			.InGlobal()
			.SetGroups("Combined")
			.AddInfo("Demonstration Rect!")
			.AddField(_rectCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_rectCheatFieldModel.Value));

		cheatBinder.Bind("Cheat Slider")
			.InGlobal()
			.SetGroups("Slider")
			.AddInfo("Demonstration Slider!")
			.AddField(_sliderCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_sliderCheatFieldModel.Value));

		cheatBinder.Bind("Cheat IntSlider")
			.InGlobal()
			.SetGroups("Slider")
			.AddInfo("Demonstration IntSlider!")
			.AddField(_intSliderCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_intSliderCheatFieldModel.Value));

		cheatBinder.Bind("Cheat MinMaxSlider")
			.InGlobal()
			.SetGroups("Combined", "Slider")
			.AddInfo("Demonstration MinMaxSlider!")
			.AddField(_minMaxSliderCheatFieldModel)
			.AddButton("Log Min", () => Debug.Log(_minMaxSliderCheatFieldModel.MinValue),
				"Log Max", () => Debug.Log(_minMaxSliderCheatFieldModel.MaxValue));

		cheatBinder.Bind("Cheat IntMinMaxSlider")
			.InGlobal()
			.SetGroups("Combined", "Slider")
			.AddInfo("Demonstration IntMinMaxSlider!")
			.AddField(_intMinMaxSliderCheatFieldModel)
			.AddButton("Log Min", () => Debug.Log(_intMinMaxSliderCheatFieldModel.MinValue),
				"Log Max", () => Debug.Log(_intMinMaxSliderCheatFieldModel.MaxValue));

		cheatBinder.Bind("Cheat StringDropdown")
			.InGlobal()
			.SetGroups("Dropdown")
			.AddInfo("Demonstration StringDropdown!")
			.AddField(_stringDropdownCheatFieldModel)
			.AddButton("Log", () => Debug.Log(_stringDropdownCheatFieldModel.CurrentValue));
		
		cheatBinder.Bind("Cheat Buttons")
			.InGlobal()
			.SetGroups("Buttons")
			.AddInfo("Demonstration Buttons!")
			.AddButton("Button", () => Debug.Log("Button"))
			.AddButton("Button1", () => Debug.Log("Button1"),
				"Button2", () => Debug.Log("Button2"))
			.AddButton("Button1", () => Debug.Log("Button1"),
				"Button2", () => Debug.Log("Button2"),
				"Button3", () => Debug.Log("Button3"));
	}

	#endregion
}

}