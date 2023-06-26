namespace EM.GameKit
{

using System;
using System.Linq;
using System.Collections.Generic;
using Foundation;

public sealed class Storage : IStorage
{
	private readonly Dictionary<(string, string), object> _models = new();

	private readonly Dictionary<ValueTuple<string, string>, ObservableField<long>> _items = new();

	#region IStorage

	public IReadOnlyDictionary<ValueTuple<string, string>, long> GetAll()
	{
		return _items.ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value.Value);
	}
	
	public void Update(string catalog,
		string itemName,
		long count)
	{
		var key = new ValueTuple<string, string>(catalog, itemName);
		var item = GetItem(key);
		item.SetValue(count);
	}

	public StorageEntry<T> Get<T>(T data)
		where T : IStorageItem
	{
		var key = new ValueTuple<string, string>(data.GetStorageCatalog(), data.GetStorageKey());

		if (!_models.TryGetValue(key, out var model))
		{
			var item = GetItem(key);
			model = new StorageEntry<T>(data, item);
			_models.Add(key, model);
		}

		return (StorageEntry<T>) model;
	}

	public void PutAmount<T>(T data,
		long amount)
		where T : IStorageItem
	{
		var storageEntry = Get(data);
		storageEntry.SetAmount(storageEntry.Amount + amount);
	}

	public void TakeAmount<T>(T data,
		long amount)
		where T : IStorageItem
	{
		var storageEntry = Get(data);
		storageEntry.SetAmount(storageEntry.Amount - amount);
	}

	#endregion

	#region Storage

	private ObservableField<long> GetItem(ValueTuple<string, string> key)
	{
		if (!_items.TryGetValue(key, out var value))
		{
			value = new ObservableField<long>();
			_items.Add(key, value);
		}

		return value;
	}

	#endregion
}

}