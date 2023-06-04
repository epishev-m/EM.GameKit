namespace EM.GameKit
{

using UnityEngine;

public sealed class IconTooltipViewModel : BaseIconTooltipViewModel
{
	public override IconTooltipLayouts Layouts => Data.Layout;
	
	public override string Icon => Data.Icon;

	public override string Title => Data.Title;

	public override string Description => Data.Description;

	public override Vector2 Position => Data.Position;

	public override Vector2 Size => Data.Size;
}

}