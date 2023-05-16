namespace EM.GameKit
{

using System;
using UnityEngine;

[Serializable]
public sealed class CheatFieldViewPrefabs
{
	[SerializeField]
	private InfoCheatFieldView _infoCheatFieldViewPrefab;

	[SerializeField]
	private BoolCheatFieldView _boolCheatFieldViewPrefab;

	[SerializeField]
	private IntCheatFieldView _intCheatFieldView;

	[SerializeField]
	private LongCheatFieldView _longCheatFieldView;

	[SerializeField]
	private FloatCheatFieldView _floatCheatFieldView;

	[SerializeField]
	private DoubleCheatFieldView _doubleCheatFieldView;

	[SerializeField]
	private TextCheatFieldView _textCheatFieldView;

	[SerializeField]
	private Vector2CheatFieldView _vector2CheatFieldView;

	[SerializeField]
	private Vector3CheatFieldView _vector3CheatFieldView;

	[SerializeField]
	private Vector4CheatFieldView _vector4CheatFieldView;

	[SerializeField]
	private RectCheatFieldView _rectCheatFieldView;

	[SerializeField]
	private SliderCheatFieldView _sliderCheatFieldView;

	[SerializeField]
	private IntSliderCheatFieldView _intSliderCheatFieldView;

	[SerializeField]
	private MinMaxSliderCheatFieldView _minMaxSliderCheatFieldView;

	[SerializeField]
	private IntMinMaxSliderCheatFieldView _intMinMaxSliderCheatFieldView;
	
	[SerializeField]
	private StringDropdownFieldView _stringDropdownFieldView;

	[SerializeField]
	private ButtonCheatFieldView _buttonCheatCheatFieldView;

	[SerializeField]
	private Button2CheatFieldView _button2CheatCheatFieldView;

	[SerializeField]
	private Button3CheatFieldView _button3CheatCheatFieldView;

	#region CheatFieldViewPrefabs

	public InfoCheatFieldView InfoCheatFieldViewPrefab => _infoCheatFieldViewPrefab;

	public BoolCheatFieldView BoolCheatFieldViewPrefab => _boolCheatFieldViewPrefab;

	public IntCheatFieldView IntCheatFieldView => _intCheatFieldView;

	public LongCheatFieldView LongCheatFieldView => _longCheatFieldView;

	public FloatCheatFieldView FloatCheatFieldView => _floatCheatFieldView;

	public DoubleCheatFieldView DoubleCheatFieldView => _doubleCheatFieldView;

	public TextCheatFieldView TextCheatFieldView => _textCheatFieldView;

	public Vector2CheatFieldView Vector2CheatFieldView => _vector2CheatFieldView;

	public Vector3CheatFieldView Vector3CheatFieldView => _vector3CheatFieldView;

	public Vector4CheatFieldView Vector4CheatFieldView => _vector4CheatFieldView;

	public RectCheatFieldView RectCheatFieldView => _rectCheatFieldView;

	public SliderCheatFieldView SliderCheatFieldView => _sliderCheatFieldView;

	public IntSliderCheatFieldView IntSliderCheatFieldView => _intSliderCheatFieldView;

	public MinMaxSliderCheatFieldView MinMaxSliderCheatFieldView => _minMaxSliderCheatFieldView;

	public IntMinMaxSliderCheatFieldView IntMinMaxSliderCheatFieldView => _intMinMaxSliderCheatFieldView;

	public StringDropdownFieldView StringDropdownFieldView => _stringDropdownFieldView;

	public ButtonCheatFieldView ButtonCheatFieldView => _buttonCheatCheatFieldView;

	public Button2CheatFieldView Button2CheatFieldView => _button2CheatCheatFieldView;

	public Button3CheatFieldView Button3CheatFieldView => _button3CheatCheatFieldView;

	#endregion
}

}