namespace EM.GameKit
{

using UnityEngine;

public interface ICurrencyTooltipDataProvider
{
	string Icon { get; }

	string Title { get; }

	string Description { get; }

	Vector2 Size { get; }

	Vector2 Position { get; }
}

}