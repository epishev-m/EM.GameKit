namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class Vector2FieldViewModel : IFieldViewModel
{
	private readonly ObservableField<float> _x = new();

	private readonly ObservableField<float> _y = new();

	private readonly ObservableField<string> _label = new();

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

	public IObservableField<float> X => _x;

	public IObservableField<float> Y => _y;

	public IObservableField<string> Label => _label;

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
		_label.SetValue(_model.Label);
		_x.SetValue(_model.Value.x);
		_y.SetValue(_model.Value.y);
	}

	#endregion
}

}