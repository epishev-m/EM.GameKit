namespace EM.GameKit
{

using Foundation;

public sealed class GameLoopBinding : Binding,
	IGameLoopBinding,
	IGameLoopBindingLifeTime
{
	#region IGameLoopLifeTime

	public LifeTime LifeTime
	{
		get;
		private set;
	} = LifeTime.External;
	
	public IGameLoopBinding InGlobal()
	{
		Requires.ValidOperation(LifeTime == LifeTime.External, this);

		LifeTime = LifeTime.Global;

		return this;
	}

	public IGameLoopBinding InLocal()
	{
		Requires.ValidOperation(LifeTime == LifeTime.External, this);

		LifeTime = LifeTime.Local;

		return this;
	}

	public IGameLoopBinding SetLifeTime(LifeTime lifeTime)
	{
		Requires.ValidOperation(LifeTime == LifeTime.External, this);

		LifeTime = lifeTime;

		return this;
	}

	#endregion

	#region IGameLoopBinding

	public new IGameLoopBinding To<T>()
		where T : class, IGameLoopObject
	{
		Requires.ValidOperation(LifeTime != LifeTime.External, this);
		Requires.ValidOperation(Values == null, this, nameof(Values));

		return base.To<T>() as IGameLoopBinding;
	}

	#endregion

	#region GameLoopBinding
	
	public GameLoopBinding(object key,
		object name,
		Resolver resolver) : base(key, name, resolver)
	{
	}

	#endregion
}

}