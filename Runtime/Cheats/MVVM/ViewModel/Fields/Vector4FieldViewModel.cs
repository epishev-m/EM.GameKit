namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class Vector4FieldViewModel : IFieldViewModel
{
	private readonly ObservableField<float> _x = new();

	private readonly ObservableField<float> _y = new();

	private readonly ObservableField<float> _z = new();

	private readonly ObservableField<float> _w = new();

	private readonly ObservableField<string> _label = new();

	private readonly Vector4CheatFieldModel _model;

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

	#region Vector4FieldViewModel

	public Vector4FieldViewModel(Vector4CheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<float> X => _x;

	public IObservableField<float> Y => _y;

	public IObservableField<float> Z => _z;

	public IObservableField<float> W => _w;

	public IObservableField<string> Label => _label;

	public void SetX(float value)
	{
		_x.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector4(value, _model.Value.y, _model.Value.z, _model.Value.w));
	}

	public void SetY(float value)
	{
		_x.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector4(_model.Value.x, value, _model.Value.z, _model.Value.w));
	}

	public void SetZ(float value)
	{
		_z.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector4(_model.Value.x, _model.Value.y, value, _model.Value.w));
	}

	public void SetW(float value)
	{
		_w.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Vector4(_model.Value.x, _model.Value.y, _model.Value.z, value));
	}

	private void OnChangeModel()
	{
		_label.SetValue(_model.Label);
		_x.SetValue(_model.Value.x);
		_y.SetValue(_model.Value.y);
		_z.SetValue(_model.Value.z);
		_w.SetValue(_model.Value.w);
	}

	#endregion
}

}