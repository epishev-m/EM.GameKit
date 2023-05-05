namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class Vector3FieldViewModel : IFieldViewModel
{
	private readonly RxProperty<float> _x = new();

	private readonly RxProperty<float> _y = new();

	private readonly RxProperty<float> _z = new();

	private readonly RxProperty<string> _label = new();

	private readonly Vector3CheatFieldModel _model;

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

	#region Vector3FieldViewModel

	public Vector3FieldViewModel(Vector3CheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<float> X => _x;

	public IRxProperty<float> Y => _y;

	public IRxProperty<float> Z => _z;

	public IRxProperty<string> Label => _label;

	public void SetX(float value)
	{
		_x.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector3(value, _model.Value.y, _model.Value.z));
	}

	public void SetY(float value)
	{
		_x.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector3(_model.Value.x, value, _model.Value.z));
	}

	public void SetZ(float value)
	{
		_z.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector3(_model.Value.x, _model.Value.y, value));
	}

	private void OnChangeModel()
	{
		_label.Value = _model.Label;
		_x.Value = _model.Value.x;
		_y.Value = _model.Value.y;
		_z.Value = _model.Value.z;
	}

	#endregion
}

}