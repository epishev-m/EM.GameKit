namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;

public sealed class GdpRegulation
{
	private readonly GdpRegulationModel _model;

	private readonly GdpRegulationRouter _router;

	#region GdpRegulation

	public GdpRegulation(GdpRegulationModel model,
		GdpRegulationRouter router)
	{
		_model = model;
		_router = router;
	}

	public async UniTask ShowAsync(CancellationToken ct)
	{
		if (_model.IsAccepted)
		{
			return;
		}

		await _router.OpenAsync(ct);
		await UniTask.WaitUntil(() => _model.IsAccepted, cancellationToken: ct);
		await _router.CloseAsync(ct);
	}

	#endregion
}

}