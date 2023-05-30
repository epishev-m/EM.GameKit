namespace EM.GameKit
{

using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;

public sealed class IconView : MonoBehaviour
{
	[SerializeField]
	private AssetReference _assetReference;

	[SerializeField]
	private ImageView _image;

	[SerializeField]
	private PreloaderView _preloaderView;

	private SpriteAtlas _spriteAtlas;

	#region MonoBehaviour

	private void Awake()
	{
		if (_spriteAtlas == null)
		{
			_image.enabled = false;
		}
	}

	private void OnDestroy()
	{
		CleanUp();
	}

	#endregion

	#region ImageView

	public bool Gray
	{
		get => _image.Gray;
		set => _image.Gray = value;
	}

	public float CoverAmount
	{
		get => _image.CoverAmount;
		set => _image.CoverAmount = value;
	}

	public Color CoverColor
	{
		get => _image.CoverColor;
		set => _image.CoverColor = value;
	}

	public async UniTask SetImageAsync(string image)
	{
		await LoadSpriteAtlas();
		var sprite = _spriteAtlas.GetSprite(image);
		_image.SetSprite(sprite);
		_image.enabled = true;
	}

	public void SetSize(Vector2 size)
	{
		if (TryGetComponent<RectTransform>(out var rectTransform))
		{
			rectTransform.sizeDelta = new Vector2(size.x, size.y);
		}
	}

	public void CleanUp()
	{
		_image.CleanUp();
		_spriteAtlas = null;
		_assetReference.ReleaseAsset();
	}

	private async UniTask LoadSpriteAtlas()
	{
		if (_spriteAtlas != null)
		{
			return;
		}

		_preloaderView.Show();
		_spriteAtlas = await _assetReference.LoadAssetAsync<SpriteAtlas>().ToUniTask();
		_preloaderView.Hide();
	}

	#endregion
}

}