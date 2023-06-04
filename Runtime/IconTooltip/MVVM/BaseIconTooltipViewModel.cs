﻿namespace EM.GameKit
{

using UI;
using UnityEngine;

public abstract class BaseIconTooltipViewModel : ViewModel<IIconTooltipDataProvider>
{
	public abstract IconTooltipLayouts Layouts { get; }

	public abstract string Icon { get; }

	public abstract string Title { get; }

	public abstract string Description { get; }

	public abstract Vector2 Position { get; }

	public abstract Vector2 Size { get; }
}

}