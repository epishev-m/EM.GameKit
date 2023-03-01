namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class SplashView : MonoBehaviour
{
	public abstract string Name
	{
		get;
	}

	public abstract UniTask ShowAsync(CancellationToken ct);

	public abstract void Hide();
}

}