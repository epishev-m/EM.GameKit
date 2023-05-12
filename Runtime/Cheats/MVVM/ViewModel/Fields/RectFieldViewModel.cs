namespace EM.GameKit
{

using Foundation;
using UnityEngine;

public sealed class RectFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<float> _x = new();

	private readonly ObservableField<float> _y = new();

	private readonly ObservableField<float> _width = new();

	private readonly ObservableField<float> _height = new();

	private readonly ObservableField<string> _label = new();

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

	public IObservableField<float> X => _x;

	public IObservableField<float> Y => _y;

	public IObservableField<float> Width => _width;

	public IObservableField<float> Height => _height;

	public IObservableField<string> Label => _label;

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
		_label.SetValue(_model.Label);
		_x.SetValue(_model.Value.x);
		_y.SetValue(_model.Value.y);
		_width.SetValue(_model.Value.width);
		_height.SetValue(_model.Value.height);
	}

	#endregion
}

}