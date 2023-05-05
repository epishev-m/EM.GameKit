namespace EM.GameKit
{

using System;
using Foundation;

public sealed class SliderFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<float> _value = new();

	private readonly SliderCheatFieldModel _model;

	#region IFieldViewModel

	void IFieldViewModel.Initialize()
	{
		_model.OnChanged += OnChangeModel;
	}

	void IFieldViewModel.Release()
	{
		_model.OnChanged -= OnChangeModel;
	}

	void IFieldViewModel.UpdateAllRxProperties()
	{
		OnChangeModel();
	}

	#endregion

	#region SliderFieldViewModel

	public SliderFieldViewModel(SliderCheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<float> Value => _value;

	public float MinLimit => _model.MinValue;

	public float MaxLimit => _model.MaxValue;

	public string Label => _model.Label;

	public void SetValue(float value)
	{
		_value.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(value);
	}

	private void OnChangeModel()
	{
		_value.Value = _model.Value;
	}

	#endregion
}

}