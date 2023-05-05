namespace EM.GameKit
{

using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using IoC;

public sealed class Cheats : IDisposable
{
#if UNITY_EDITOR
	public static CheatsModel CheatsModel { get; set; }
#endif

	private readonly IDiContainer _diContainer;

	private readonly ICheatBinder _cheatBinder;

	#region IDisposable

	public void Dispose()
	{
#if UNITY_EDITOR
		CheatsModel = null;
#endif
	}

	#endregion

	#region Cheats

	public Cheats(IDiContainer diContainer,
#if UNITY_EDITOR
		CheatsModel cheatsModel,
#endif
		ICheatBinder cheatBinder)
	{
		_diContainer = diContainer;
		_cheatBinder = cheatBinder;

#if UNITY_EDITOR
		Requires.Null(CheatsModel, nameof(CheatsModel));

		CheatsModel = cheatsModel;
#endif
	}

	public Cheats Add<T>()
		where T : class, ICheat
	{
		var cheat = _diContainer.Resolve<T>();
		cheat.Registration(_cheatBinder);

		return this;
	}

	#endregion
}

}