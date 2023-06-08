namespace EM.GameKit
{

using UnityEngine;
using Configs;

public interface IIconTooltipDataProvider
{
	IconTooltipLayouts Layout { get; }

	SpriteAtlasDefinition Icon { get; }

	string Title { get; }

	string Description { get; }

	Vector2 Size { get; }

	Vector2 Position { get; }
}

}