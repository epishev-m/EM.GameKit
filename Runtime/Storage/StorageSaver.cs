namespace EM.GameKit
{

using System.Linq;
using System.Collections.Generic;
using Profile;

public sealed class StorageSaver : IStorageSegmentSaver
{
	private readonly IStorage _storage;

	#region IStorageSegmentSaver

	public IProfileStorageSegment Save()
	{
		return new StorageProfileStorageSegment
		{
			Items = _storage.GetAll()
				.Select(pair =>
					new Item
					{
						Type = pair.Key.Item1,
						Subtype = pair.Key.Item2,
						Value = pair.Value
					})
				.ToList()
		};
	}

	public bool Load(IProfileStorageSegment segment)
	{
		if (segment is not StorageProfileStorageSegment storageSegment)
		{
			return false;
		}

		foreach (var item in storageSegment.Items)
		{
			_storage.Update(item.Type, item.Subtype, item.Value);
		}

		return true;
	}

	#endregion

	#region StorageSaver

	public StorageSaver(IStorage storage)
	{
		_storage = storage;
	}

	#endregion

	#region Nested

	[JsonSerialize("F4032051-E8BE-4079-9303-BCA57F3081EC")]
	private sealed class StorageProfileStorageSegment : IProfileStorageSegment
	{
		public List<Item> Items;
	}

	private sealed class Item
	{
		public string Type;

		public string Subtype;

		public long Value;
	}

	#endregion
}

}