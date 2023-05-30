namespace EM.GameKit
{

using UnityEngine;
using UnityEngine.UI;

public sealed class ImageView : MonoBehaviour
{
	[SerializeField]
	private Image _image;

	private bool _isAwaked;

	private Color _color = Color.white;

	private Material _material;

	private bool _gray;

	private float _coverAmount;

	private Color _coverColor;

	#region MonoBehaviour

	private void Awake()
	{
		_color = _image.color;
		_isAwaked = true;
	}

	#endregion

	#region ImageView

	public bool Gray
	{
		get => _gray;
		set
		{
			if (_gray == value)
			{
				return;
			}

			_gray = value;
			CreateMaterial();
			_material.SetFloat(ShaderConstants.Properties.GrayAmount, _gray ? 1f : 0f);
		}
	}

	public float CoverAmount
	{
		get => _coverAmount;
		set
		{
			if (_coverAmount == value)
			{
				return;
			}

			_coverAmount = value;
			CreateMaterial();
			_material.SetFloat(ShaderConstants.Properties.CoverAmount, value);
		}
	}

	public Color CoverColor
	{
		get => _coverColor;
		set
		{
			if (_coverColor == value)
			{
				return;
			}

			_coverColor = value;
			CreateMaterial();
			_material.SetColor(ShaderConstants.Properties.CoverColor, value);
		}
	}

	public void SetSprite(Sprite sprite)
	{
		if (_image.sprite == sprite)
		{
			return;
		}

		_image.sprite = sprite;

		if (_material != null)
		{
			_material.mainTexture = _image.mainTexture;
		}
	}

	public void CleanUp()
	{
		if (_material != null)
		{
			Destroy(_material);
			_material = null;
		}

		if (_isAwaked)
		{
			_image.color = _color;
		}

		_gray = false;
	}

	private void CreateMaterial()
	{
		if (_material != null)
		{
			return;
		}

		_material = new Material(Shader.Find(ShaderConstants.Names.CoverColor));
		_image.material = _material;
		_material.mainTexture = _image.mainTexture;
	}

	#endregion
}

}