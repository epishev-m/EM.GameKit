﻿namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class IconTooltipRouter
{
	private readonly IPanelSystem _panelSystem;

	#region IconTooltipRouter

	public IconTooltipRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(IIconTooltipData data,
		CancellationToken ct)
	{
		await _panelSystem.OpenAsync<IconTooltipView, IconTooltipViewModel, IIconTooltipData>(data, ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<IconTooltipView>(ct);
	}

	#endregion
}

}