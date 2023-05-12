namespace EM.GameKit
{

using System;
using Foundation;

public sealed class Cheats : IDisposable
{
#if UNITY_EDITOR
	public static CheatsModel CheatsModel { get; set; }
#endif

	private readonly ICheatFactory _cheatFactory;

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

	public Cheats(ICheatFactory cheatFactory,
#if UNITY_EDITOR
		CheatsModel cheatsModel,
#endif
		ICheatBinder cheatBinder)
	{
		_cheatFactory = cheatFactory;
		_cheatBinder = cheatBinder;

#if UNITY_EDITOR
		Requires.Null(CheatsModel, nameof(CheatsModel));

		CheatsModel = cheatsModel;
#endif
	}

	public Cheats Add<T>()
		where T : class, ICheat
	{
		var cheat = _cheatFactory.Get<T>();
		cheat.Registration(_cheatBinder);

		return this;
	}

	#endregion
}

}