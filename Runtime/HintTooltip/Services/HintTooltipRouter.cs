namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class HintTooltipRouter
{
	private readonly IPanelSystem _panelSystem;

	#region IconTooltipRouter

	public HintTooltipRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(string message,
		CancellationToken ct)
	{
		if (_panelSystem.IsOpened<HintTooltipPanelView>())
		{
			return;
		}
		
		var data = new HintTooltipData
		{
			Message = message
		};

		await _panelSystem.OpenAsync<HintTooltipPanelView, HintTooltipViewModel, IHintTooltipData>(data, ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<HintTooltipPanelView>(ct);
	}

	#endregion
}

}