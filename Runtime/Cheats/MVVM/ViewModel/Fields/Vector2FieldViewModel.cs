namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class Vector2FieldViewModel : IFieldViewModel
{
	private readonly RxProperty<float> _x = new();

	private readonly RxProperty<float> _y = new();

	private readonly RxProperty<string> _label = new();

	private readonly Vector2CheatFieldModel _model;

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

	#region FloatFieldViewModel

	public Vector2FieldViewModel(Vector2CheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<float> X => _x;

	public IRxProperty<float> Y => _y;

	public IRxProperty<string> Label => _label;

	public void SetX(float value)
	{
		_x.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector2(value, _model.Value.y));
	}

	public void SetY(float value)
	{
		_x.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector2(_model.Value.x, value));
	}

	private void OnChangeModel()
	{
		_label.Value = _model.Label;
		_x.Value = _model.Value.x;
		_y.Value = _model.Value.y;
	}

	#endregion
}

}