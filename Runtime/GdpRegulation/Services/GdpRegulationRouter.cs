namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class GdpRegulationRouter
{
	private readonly IPanelSystem _panelSystem;

	#region GdpRegulationRouter

	public GdpRegulationRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _panelSystem.OpenAsync<GdpRegulationView, GdpRegulationViewModel>(Modes.Modal, ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<GdpRegulationView>(ct);
	}

	#endregion
}

}