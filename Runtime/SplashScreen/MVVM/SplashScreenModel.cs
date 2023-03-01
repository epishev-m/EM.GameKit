namespace EM.GameKit
{

using System;
using Foundation;

public sealed class SplashScreenModel
{
	public event Action OnStarted;

	public bool IsFinished { get; private set; }

	public void Start()
	{
		Requires.ValidOperation(!IsFinished, this);

		OnStarted?.Invoke();
	}
	
	public void Finish()
	{
		IsFinished = true;
	}
}

}