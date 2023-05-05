namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class RectFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<float> _x = new();

	private readonly RxProperty<float> _y = new();

	private readonly RxProperty<float> _width = new();

	private readonly RxProperty<float> _height = new();

	private readonly RxProperty<string> _label = new();

	private readonly RectCheatFieldModel _model;

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

	#region RectFieldViewModel

	public RectFieldViewModel(RectCheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<float> X => _x;

	public IRxProperty<float> Y => _y;

	public IRxProperty<float> Width => _width;

	public IRxProperty<float> Height => _height;

	public IRxProperty<string> Label => _label;

	public void SetX(float value)
	{
		_x.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Rect(value, _model.Value.y, _model.Value.width, _model.Value.height));
	}

	public void SetY(float value)
	{
		_x.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Rect(_model.Value.x, value, _model.Value.width, _model.Value.height));
	}

	public void SetWidth(float value)
	{
		_width.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Rect(_model.Value.x, _model.Value.y, value, _model.Value.height));
	}

	public void SetHeight(float value)
	{
		_height.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(new Rect(_model.Value.x, _model.Value.y, _model.Value.width, value));
	}

	private void OnChangeModel()
	{
		_label.Value = _model.Label;
		_x.Value = _model.Value.x;
		_y.Value = _model.Value.y;
		_width.Value = _model.Value.width;
		_height.Value = _model.Value.height;
	}

	#endregion
}

}