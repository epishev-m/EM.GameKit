using System.Collections.Generic;
using System.Linq;
using EM.Assistant.Editor;
using UnityEngine;
using UnityEngine.UIElements;

namespace EM.GameKit.Editor
{

public sealed class CheatsComponent : VisualElement
{
	private readonly IEnumerable<ICheatFieldModel> _fields;

	private Foldout _foldout;

	private VisualElement _allFields;

	#region CheatsComponent

	public CheatsComponent(string name,
		IEnumerable<ICheatFieldModel> fields)
	{
		Name = name;
		_fields = fields;

		Initialize();
		Compose();
	}

	public string Name { get; }

	public void Show()
	{
		_foldout?.SetValueWithoutNotify(true);
	}

	public void Hide()
	{
		_foldout?.SetValueWithoutNotify(false);
	}

	private void Initialize()
	{
		CreateFoldout();
		CreateAllFields();
	}

	private void Compose()
	{
		Add(_foldout
			.AddChild(_allFields));
	}

	private void CreateFoldout()
	{
		_foldout = new Foldout()
			.SetStylePadding(5)
			.SetStyleMargin(5, 5, 0, 0)
			.SetText(Name)
			.SetStyleBorderWidth(1)
			.SetStyleBorderColor(Color.gray);
	}

	private void CreateAllFields()
	{
		_allFields = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Column)
			.SetStyleJustifyContent(Justify.SpaceAround);

		foreach (var field in _fields)
		{
			var fieldVisualElement = CreateField(field);
			_allFields.AddChild(fieldVisualElement);
		}
	}

	private static VisualElement CreateField(ICheatFieldModel field)
	{
		return field switch
		{
			InfoCheatFieldModel fieldModel => CreateInfoVisualElement(fieldModel),
			BoolCheatFieldModel fieldModel => CreateBoolVisualElement(fieldModel),
			IntCheatFieldModel fieldModel => CreateIntVisualElement(fieldModel),
			FloatCheatFieldModel fieldModel => CreateFloatVisualElement(fieldModel),
			LongCheatFieldModel fieldModel => CreateLongVisualElement(fieldModel),
			DoubleCheatFieldModel fieldModel => CreateDoubleVisualElement(fieldModel),
			Vector2CheatFieldModel fieldModel => CreateVector2VisualElement(fieldModel),
			Vector3CheatFieldModel fieldModel => CreateVector3VisualElement(fieldModel),
			Vector4CheatFieldModel fieldModel => CreateVector4VisualElement(fieldModel),
			SliderCheatFieldModel fieldModel => CreateSliderVisualElement(fieldModel),
			IntSliderCheatFieldModel fieldModel => CreateIntSliderVisualElement(fieldModel),
			MinMaxSliderCheatFieldModel fieldModel => CreateMinMaxSliderVisualElement(fieldModel),
			IntMinMaxSliderCheatFieldModel fieldModel => CreateIntMinMaxSliderVisualElement(fieldModel),
			RectCheatFieldModel fieldModel => CreateRectVisualElement(fieldModel),
			TextCheatFieldModel fieldModel => CreateTextVisualElement(fieldModel),
			StringDropdownCheatFieldModel fieldModel => CreateStringDropdownVisualElement(fieldModel),
			ButtonCheatFieldModel fieldModel => CreateButtonVisualElement(fieldModel),
			Button2CheatFieldModel fieldModel => CreateButton2VisualElement(fieldModel),
			Button3CheatFieldModel fieldModel => CreateButton3VisualElement(fieldModel),
			_ => null
		};
	}

	private static VisualElement CreateInfoVisualElement(InfoCheatFieldModel fieldModel)
	{
		var field = new HelpBox(fieldModel.Info, HelpBoxMessageType.Info);

		return field;
	}

	private static VisualElement CreateBoolVisualElement(BoolCheatFieldModel fieldModel)
	{
		var field = new Toggle(fieldModel.Label)
			.AddValueChangedCallback<Toggle, bool>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateIntVisualElement(IntCheatFieldModel fieldModel)
	{
		var field = new IntegerField(fieldModel.Label)
			.AddValueChangedCallback<IntegerField, int>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateFloatVisualElement(FloatCheatFieldModel fieldModel)
	{
		var field = new FloatField(fieldModel.Label)
			.AddValueChangedCallback<FloatField, float>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateLongVisualElement(LongCheatFieldModel fieldModel)
	{
		var field = new LongField(fieldModel.Label)
			.AddValueChangedCallback<LongField, long>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateDoubleVisualElement(DoubleCheatFieldModel fieldModel)
	{
		var field = new DoubleField(fieldModel.Label)
			.AddValueChangedCallback<DoubleField, double>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateVector2VisualElement(Vector2CheatFieldModel fieldModel)
	{
		var field = new Vector2Field(fieldModel.Label)
			.AddValueChangedCallback<Vector2Field, Vector2>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateVector3VisualElement(Vector3CheatFieldModel fieldModel)
	{
		var field = new Vector3Field(fieldModel.Label)
			.AddValueChangedCallback<Vector3Field, Vector3>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateVector4VisualElement(Vector4CheatFieldModel fieldModel)
	{
		var field = new Vector4Field(fieldModel.Label)
			.AddValueChangedCallback<Vector4Field, Vector4>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateSliderVisualElement(SliderCheatFieldModel fieldModel)
	{
		var fieldSlider = new Slider(fieldModel.Label, fieldModel.MinValue, fieldModel.MaxValue)
			.AddValueChangedCallback<Slider, float>(value => fieldModel.Value = value);

		var valueField = new FloatField("Value:")
		{
			value = fieldModel.Value
		};
		valueField.AddValueChangedCallback<FloatField, float>(value =>
		{
			value = Mathf.Clamp(value, fieldModel.MinValue, fieldModel.MaxValue);
			valueField.SetValueWithoutNotify(value);
			fieldModel.Value = value;
			fieldSlider.SetValueWithoutNotify(fieldModel.Value);
		});

		fieldModel.OnChanged += () =>
		{
			fieldSlider.SetValueWithoutNotify(fieldModel.Value);
			valueField.SetValueWithoutNotify(fieldModel.Value);
		};

		var field = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Column)
			.AddChild(fieldSlider)
			.AddChild(valueField);

		return field;
	}

	private static VisualElement CreateIntSliderVisualElement(IntSliderCheatFieldModel fieldModel)
	{
		var fieldSlider = new SliderInt(fieldModel.Label, fieldModel.MinLimit, fieldModel.MaxLimit)
			.AddValueChangedCallback<SliderInt, int>(value => fieldModel.Value = value);

		var valueField = new IntegerField("Value:")
		{
			value = fieldModel.Value
		};
		valueField.AddValueChangedCallback<IntegerField, int>(value =>
		{
			value = Mathf.Clamp(value, fieldModel.MinLimit, fieldModel.MaxLimit);
			valueField.SetValueWithoutNotify(value);
			fieldModel.Value = value;
			fieldSlider.SetValueWithoutNotify(fieldModel.Value);
		});

		fieldModel.OnChanged += () =>
		{
			fieldSlider.SetValueWithoutNotify(fieldModel.Value);
			valueField.SetValueWithoutNotify(fieldModel.Value);
		};

		var field = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Column)
			.AddChild(fieldSlider)
			.AddChild(valueField);

		return field;
	}

	private static VisualElement CreateMinMaxSliderVisualElement(MinMaxSliderCheatFieldModel fieldModel)
	{
		var minMaxSlider = new UnityEngine.UIElements.MinMaxSlider(fieldModel.Label,
			fieldModel.MinValue, fieldModel.MaxValue,
			fieldModel.MinLimit, fieldModel.MaxLimit);

		var minValueField = new FloatField("Min Value:")
		{
			value = fieldModel.MinValue
		};
		minValueField.AddValueChangedCallback<FloatField, float>(value =>
		{
			value = Mathf.Clamp(value, fieldModel.MinValue, fieldModel.MaxValue);
			fieldModel.MinValue = value;
			minMaxSlider.SetValueWithoutNotify(new Vector2(fieldModel.MinValue, fieldModel.MaxValue));
		});

		var maxValueField = new FloatField("Max Value:")
		{
			value = fieldModel.MinValue
		};
		maxValueField.AddValueChangedCallback<FloatField, float>(value =>
		{
			fieldModel.MaxValue = value;
			minMaxSlider.SetValueWithoutNotify(new Vector2(fieldModel.MinValue, fieldModel.MaxValue));
		});

		minMaxSlider.AddValueChangedCallback<UnityEngine.UIElements.MinMaxSlider, Vector2>(value =>
		{
			fieldModel.MinValue = value.x;
			fieldModel.MaxValue = value.y;
			minValueField.SetValueWithoutNotify(fieldModel.MinValue);
			maxValueField.SetValueWithoutNotify(fieldModel.MaxValue);
		});

		fieldModel.OnChanged += () =>
		{
			minValueField.SetValueWithoutNotify(fieldModel.MinValue);
			maxValueField.SetValueWithoutNotify(fieldModel.MaxValue);
			minMaxSlider.SetValueWithoutNotify(new Vector2(fieldModel.MinValue, fieldModel.MaxValue));
		};

		var field = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Column)
			.AddChild(minMaxSlider)
			.AddChild(minValueField)
			.AddChild(maxValueField);

		return field;
	}

	private static VisualElement CreateIntMinMaxSliderVisualElement(IntMinMaxSliderCheatFieldModel fieldModel)
	{
		var minMaxSlider = new UnityEngine.UIElements.MinMaxSlider(fieldModel.Label,
			fieldModel.MinValue, fieldModel.MaxValue,
			fieldModel.MinLimit, fieldModel.MaxLimit);

		var minValueField = new IntegerField("Min Value:")
		{
			value = fieldModel.MinValue
		};
		minValueField.AddValueChangedCallback<IntegerField, int>(value =>
		{
			fieldModel.MinValue = value;
			minMaxSlider.SetValueWithoutNotify(new Vector2(fieldModel.MinValue, fieldModel.MaxValue));
		});

		var maxValueField = new IntegerField("Max Value:")
		{
			value = fieldModel.MinValue
		};
		maxValueField.AddValueChangedCallback<IntegerField, int>(value =>
		{
			fieldModel.MaxValue = value;
			minMaxSlider.SetValueWithoutNotify(new Vector2(fieldModel.MinValue, fieldModel.MaxValue));
		});

		minMaxSlider.AddValueChangedCallback<UnityEngine.UIElements.MinMaxSlider, Vector2>(value =>
		{
			fieldModel.MinValue = (int) value.x;
			fieldModel.MaxValue = (int) value.y;
			minMaxSlider.SetValueWithoutNotify(new Vector2(fieldModel.MinValue, fieldModel.MaxValue));
		});

		fieldModel.OnChanged += () =>
		{
			minValueField.SetValueWithoutNotify(fieldModel.MinValue);
			maxValueField.SetValueWithoutNotify(fieldModel.MaxValue);
			minMaxSlider.SetValueWithoutNotify(new Vector2(fieldModel.MinValue, fieldModel.MaxValue));
		};

		var field = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Column)
			.AddChild(minMaxSlider)
			.AddChild(minValueField)
			.AddChild(maxValueField);

		return field;
	}

	private static VisualElement CreateRectVisualElement(RectCheatFieldModel fieldModel)
	{
		var field = new RectField(fieldModel.Label)
			.AddValueChangedCallback<RectField, Rect>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateTextVisualElement(TextCheatFieldModel fieldModel)
	{
		var field = new TextField(fieldModel.Label)
			.AddValueChangedCallback<TextField, string>(value => fieldModel.Value = value);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.Value);
		};

		return field;
	}

	private static VisualElement CreateStringDropdownVisualElement(StringDropdownCheatFieldModel fieldModel)
	{
		var field = new DropdownField(fieldModel.Label, fieldModel.Options.ToList(), 0);
		field.AddValueChangedCallback<DropdownField, string>(_ => fieldModel.Index = field.index);

		fieldModel.OnChanged += () =>
		{
			field.SetValueWithoutNotify(fieldModel.CurrentValue);
		};

		return field;
	}

	private static VisualElement CreateButtonVisualElement(ButtonCheatFieldModel field)
	{
		var button = new Button(field.Action)
			.SetText(field.Label)
			.SetStyleFlexBasisPercent(100);

		var visualElement = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMinHeight(22)
			.AddChild(button);

		return visualElement;
	}

	private static VisualElement CreateButton2VisualElement(Button2CheatFieldModel buttonFieldModel)
	{
		var button1 = new Button(buttonFieldModel.Action1)
			.SetText(buttonFieldModel.Label1)
			.SetStyleFlexBasisPercent(50);

		var button2 = new Button(buttonFieldModel.Action2)
			.SetText(buttonFieldModel.Label2)
			.SetStyleFlexBasisPercent(50);

		var visualElement = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.AddChild(button1)
			.AddChild(button2);

		return visualElement;
	}

	private static VisualElement CreateButton3VisualElement(Button3CheatFieldModel buttonFieldModel)
	{
		var button1 = new Button(buttonFieldModel.Action1)
			.SetText(buttonFieldModel.Label1)
			.SetStyleFlexBasisPercent(33.3f);

		var button2 = new Button(buttonFieldModel.Action2)
			.SetText(buttonFieldModel.Label2)
			.SetStyleFlexBasisPercent(33.3f);

		var button3 = new Button(buttonFieldModel.Action3)
			.SetText(buttonFieldModel.Label3)
			.SetStyleFlexBasisPercent(33.3f);

		var visualElement = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMinHeight(22)
			.AddChild(button1)
			.AddChild(button2)
			.AddChild(button3);

		return visualElement;
	}

	#endregion
}

}