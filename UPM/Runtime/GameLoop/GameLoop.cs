namespace EM.GameKit
{

using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UnityEngine;

public sealed class GameLoop : Binder,
	IGameLoop,
	IDisposable
{
	private readonly IGameLoopObjectFactory _factory;

	private readonly List<RunInfo> _runObjectList = new();

	private GameLoopComponent _gameLoopComponent;

	#region IDisposable

	void IDisposable.Dispose()
	{
		if (_gameLoopComponent == null)
		{
			return;
		}

		_gameLoopComponent.OnTick -= Tick;
		_gameLoopComponent.OnPause -= Paused;
		_gameLoopComponent.OnResume -= Resumed;
	}

	#endregion

	#region IGameLoop

	public void CreateGameLoopComponent()
	{
		Requires.ValidOperation(_gameLoopComponent == null, this);

		var gameObject = new GameObject(nameof(GameLoop));
		_gameLoopComponent = gameObject.AddComponent<GameLoopComponent>();
		_gameLoopComponent.OnTick += Tick;
		_gameLoopComponent.OnPause += Paused;
		_gameLoopComponent.OnResume += Resumed;

		//The condition is necessary for the correct operation of unit tests
		if (Application.isPlaying)
		{
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}
	}

	public void Run(object key)
	{
		var runInfo = _runObjectList.FirstOrDefault(runInfo => runInfo.Key == key);

		if (runInfo != null)
		{
			runInfo.IsRun = true;

			return;
		}

		if (GetBinding(key) is not GameLoopBinding binding)
		{
			return;
		}

		var gameLoopObjects = GetGameLoopObjects(binding.Values);
		runInfo = CreateRunInfo(key, gameLoopObjects);
		_runObjectList.Add(runInfo);
	}

	public void Stop(object key)
	{
		var runInfo = _runObjectList.FirstOrDefault(runInfo => runInfo.Key == key);

		if (runInfo != null)
		{
			runInfo.IsRun = false;
		}
	}

	public IGameLoopBindingLifeTime Bind(object key)
	{
		return base.Bind(key) as IGameLoopBindingLifeTime;
	}

	public bool Unbind(object key)
	{
		return base.Unbind(key);
	}

	public void Unbind(LifeTime lifeTime)
	{
		Unbind(binding =>
		{
			var diBinding = (IGameLoopBindingLifeTime) binding;
			var result = diBinding.LifeTime == lifeTime;

			if (result)
			{
				RemoveRunInfo(binding.Key);
			}

			return result;
		});
	}

	#endregion

	#region Binder

	protected override IBinding GetRawBinding(object key,
		object name)
	{
		return new GameLoopBinding(key, name, BindingResolver);
	}

	#endregion

	#region GameLoop

	public GameLoop(IGameLoopObjectFactory factory)
	{
		_factory = factory;
	}

	private IEnumerable<IGameLoopObject> GetGameLoopObjects(IEnumerable<object> values)
	{
		var gameLoopObjects = new List<IGameLoopObject>();

		foreach (var value in values)
		{
			var receiver = _factory.Get((Type) value);

			if (receiver == null)
			{
				continue;
			}

			receiver.Initialize();
			gameLoopObjects.Add(receiver);
		}

		return gameLoopObjects;
	}

	private static RunInfo CreateRunInfo(object key,
		IEnumerable<IGameLoopObject> gameLoopObjects)
	{
		var result = new RunInfo()
		{
			Key = key,
			IsRun = true,
			Objects = gameLoopObjects
		};

		return result;
	}

	private void RemoveRunInfo(object key)
	{
		var runInfo = _runObjectList.FirstOrDefault(info => info.Key == key);

		if (runInfo == null)
		{
			return;
		}

		foreach (var obj in runInfo.Objects)
		{
			obj.Release();
		}

		_runObjectList.Remove(runInfo);
	}

	private void Tick(float deltaTime)
	{
		foreach (var runInfo in _runObjectList)
		{
			if (!runInfo.IsRun)
			{
				continue;
			}

			foreach (var gameLoopObject in runInfo.Objects)
			{
				gameLoopObject.Tick(deltaTime);
			}
		}
	}

	private void Paused()
	{
		foreach (var runInfo in _runObjectList)
		{
			foreach (var gameLoopObject in runInfo.Objects)
			{
				gameLoopObject.TurnOn();
			}
		}
	}

	private void Resumed()
	{
		foreach (var runInfo in _runObjectList)
		{
			foreach (var gameLoopObject in runInfo.Objects)
			{
				gameLoopObject.TurnOff();
			}
		}
	}

	#endregion

	#region Nested

	private sealed class RunInfo
	{
		public object Key;

		public bool IsRun;

		public IEnumerable<IGameLoopObject> Objects;
	}

	#endregion
}

}