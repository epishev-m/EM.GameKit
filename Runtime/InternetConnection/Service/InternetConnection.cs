namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class InternetConnection
{
	private readonly InternetConnectionRouter _router;

	#region InternetConnection

	public InternetConnection(InternetConnectionRouter router)
	{
		_router = router;
	}

	public async UniTask CheckAsync(CancellationToken ct)
	{
		while (Application.internetReachability == NetworkReachability.NotReachable)
		{
			await _router.OpenAsync(ct);
			await _router.WaiteForCloseAsync(ct);
		}
	}

	#endregion
}

}