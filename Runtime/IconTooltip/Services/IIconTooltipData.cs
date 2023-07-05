namespace EM.GameKit
{

using UnityEngine;
using Configs;

public interface IIconTooltipData
{
	IconTooltipLayouts Layout { get; }

	ISpriteAtlas Icon { get; }

	string Title { get; }

	string Description { get; }

	Vector2 Size { get; }

	Vector3 Position { get; }
}

}