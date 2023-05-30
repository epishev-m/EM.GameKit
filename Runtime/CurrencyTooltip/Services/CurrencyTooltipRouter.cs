namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class CurrencyTooltipRouter
{
	private readonly IPanelSystem _panelSystem;

	#region GdpRegulationRouter

	public CurrencyTooltipRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(ICurrencyTooltipDataProvider dataProvider,
		CancellationToken ct)
	{
		await _panelSystem.OpenAsync<CurrencyTooltipView, SimpleCurrencyTooltipViewModel, ICurrencyTooltipDataProvider>(dataProvider, ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<CurrencyTooltipView>(ct);
	}

	#endregion
}

}