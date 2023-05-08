namespace EM.GameKit
{

using System;
using IoC;
using Profile;

public sealed class StorageSegmentReceiverFactory : IStorageSegmentReceiverFactory
{
	private readonly IDiContainer _diContainer;

	#region IStorageSegmentReceiverFactory

	public IStorageSegmentSaver Get(Type type)
	{
		return _diContainer.Resolve(type) as IStorageSegmentSaver;
	}

	#endregion

	#region ReceiverFactory

	public StorageSegmentReceiverFactory(IDiContainer diContainer)
	{
		_diContainer = diContainer;
	}

	#endregion
}

}