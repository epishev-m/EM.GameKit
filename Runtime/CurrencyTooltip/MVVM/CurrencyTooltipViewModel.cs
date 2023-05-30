namespace EM.GameKit
{

using UI;
using UnityEngine;

public abstract class CurrencyTooltipViewModel : ViewModel<ICurrencyTooltipDataProvider>
{
	public abstract string Icon { get; }

	public abstract string Title { get; }

	public abstract string Description { get; }

	public abstract Vector2 Position { get; }

	public abstract Vector2 Size { get; }
}

}