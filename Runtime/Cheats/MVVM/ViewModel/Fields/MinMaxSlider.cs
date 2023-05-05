namespace EM.GameKit
{

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinMaxSlider : MonoBehaviour
{
	[SerializeField]
	private Slider _sliderMin;

	[SerializeField]
	private Slider _sliderMax;

	[SerializeField]
	private RectTransform _fillArea;

	[SerializeField]
	private RectTransform _fillRect;

	[SerializeField]
	private float _minLimit;

	[SerializeField]
	private float _maxLimit;

	[SerializeField]
	private float _minDistance;

	[SerializeField]
	private bool _wholeNumbers;

	public UnityEvent<float> OnMinValueChanged;

	public UnityEvent<float> OnMaxValueChanged;

	#region MonoBehaviour

	private void Awake()
	{
		_sliderMin.wholeNumbers = _wholeNumbers;
		_sliderMax.wholeNumbers = _wholeNumbers;
	}

	private void OnEnable()
	{
		_sliderMin.onValueChanged.AddListener(OnValueChangedMinSlider);
		_sliderMax.onValueChanged.AddListener(OnValueChangedMaxSlider);
	}

	private void OnDisable()
	{
		_sliderMin.onValueChanged.RemoveAllListeners();
		_sliderMax.onValueChanged.RemoveAllListeners();
	}

	#endregion

	#region MinMaxSlider

	public bool IsEnabled
	{
		get => _sliderMin.interactable && _sliderMax.interactable;
		set
		{
			_sliderMin.interactable = value;
			_sliderMax.interactable = value;
		}
	}

	public float MinValue
	{
		get => _sliderMin.value;
		set
		{
			_sliderMin.value = value;
			var validateMinValue = ValidateMinValue(value);
			OnMinValueChanged.Invoke(validateMinValue);
		}
	}

	public float MaxValue
	{
		get => _sliderMax.value;
		set
		{
			_sliderMax.value = value;
			var validateMaxValue = ValidateMaxValue(value);
			OnMaxValueChanged.Invoke(validateMaxValue);
		}
	}

	public float MinLimit
	{
		get => _minLimit;
		set
		{
			_minLimit = value;
			_sliderMin.minValue = value;
			_sliderMax.minValue = value;
		}
	}

	public float MaxLimit
	{
		get => _maxLimit;
		set
		{
			_maxLimit = value;
			_sliderMin.maxValue = value;
			_sliderMax.maxValue = value;
		}
	}

	public float MinDistance
	{
		get => _minDistance;
		set => _minDistance = value;
	}

	public void SetMinValueWithoutNotify(float value)
	{
		_sliderMin.SetValueWithoutNotify(value);
		ValidateMinValue(value);
	}

	public void SetMaxValueWithoutNotify(float value)
	{
		_sliderMax.SetValueWithoutNotify(value);
		ValidateMaxValue(value);
	}

	private float ValidateMinValue(float value)
	{
		var offset = (MinValue - _minLimit) / (_maxLimit - _minLimit) * _fillArea.rect.width;
		_fillRect.offsetMin = new Vector2(offset, _fillRect.offsetMin.y);

		if (MaxValue - value < _minDistance)
		{
			_sliderMin.value = MaxValue - _minDistance;
		}

		return _sliderMin.value;
	}

	private float ValidateMaxValue(float value)
	{
		var offset = (1 - (MaxValue - _minLimit) / (_maxLimit - _minLimit)) * _fillArea.rect.width;
		_fillRect.offsetMax = new Vector2(-offset, _fillRect.offsetMax.y);

		if (value - MinValue < _minDistance)
		{
			_sliderMax.value = MinValue + _minDistance;
		}

		return _sliderMax.value;
	}

	private void OnValueChangedMinSlider(float value)
	{
		var validateMinValue = ValidateMinValue(value);
		OnMinValueChanged.Invoke(validateMinValue);
	}

	private void OnValueChangedMaxSlider(float value)
	{
		var maxValue = ValidateMaxValue(value);
		OnMaxValueChanged.Invoke(maxValue);
	}

	#endregion
}

}