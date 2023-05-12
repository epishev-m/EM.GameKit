namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class Vector3FieldViewModel : IFieldViewModel
{
	private readonly ObservableField<float> _x = new();

	private readonly ObservableField<float> _y = new();

	private readonly ObservableField<float> _z = new();

	private readonly ObservableField<string> _label = new();

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

	public IObservableField<float> X => _x;

	public IObservableField<float> Y => _y;

	public IObservableField<float> Z => _z;

	public IObservableField<string> Label => _label;

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
		_label.SetValue(_model.Label);
		_x.SetValue(_model.Value.x);
		_y.SetValue(_model.Value.y);
		_z.SetValue(_model.Value.z);
	}

	#endregion
}

}