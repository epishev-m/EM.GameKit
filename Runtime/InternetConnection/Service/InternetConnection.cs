namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class InternetConnection
{
	private readonly InternetConnectionRouter _router;

	private readonly IInternetConnectionConfigProvider _configProvider;

	#region InternetConnection

	public InternetConnection(InternetConnectionRouter router,
		IInternetConnectionConfigProvider configProvider)
	{
		_router = router;
		_configProvider = configProvider;
	}

	public async UniTask CheckAsync(CancellationToken ct)
	{
		if (!_configProvider.IsUsed)
		{
			return;
		}
		
		while (Application.internetReachability == NetworkReachability.NotReachable)
		{
			await _router.OpenAsync(ct);
			await _router.WaiteForCloseAsync(ct);
		}
	}

	#endregion
}

}