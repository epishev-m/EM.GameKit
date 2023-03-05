namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UI;

public sealed class GdpRegulationRouter
{
	private readonly IUiSystem _uiSystem;

	#region GdpRegulationRouter

	public GdpRegulationRouter(IUiSystem uiSystem)
	{
		_uiSystem = uiSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _uiSystem.OpenAsync<GdpRegulationView, GdpRegulationViewModel>(Modes.Modal, ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _uiSystem.CloseAsync<GdpRegulationView>(ct);
	}

	#endregion
}

}