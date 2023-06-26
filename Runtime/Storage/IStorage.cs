namespace EM.GameKit
{

using System;
using System.Collections.Generic;

public interface IStorage
{
	IReadOnlyDictionary<ValueTuple<string, string>, long> GetAll();

	void Update(string catalog,
		string itemName,
		long count);

	StorageEntry<T> Get<T>(T data)
		where T : IStorageItem;

	void PutAmount<T>(T data,
		long amount)
		where T : IStorageItem;

	void TakeAmount<T>(T data,
		long amount)
		where T : IStorageItem;
}

}