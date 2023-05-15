namespace EM.GameKit
{

using System;
using System.Collections.Generic;
using Foundation;

public class StorageEntry<T>
	where T : IStorageItem
{
	public event Action<StorageEntry<T>> OnAmountChanged;

	public event Action<StorageEntry<T>> OnVisualAmountChanged;

	public readonly T Data;

	private readonly LinkedList<StorageItemHolder> _holders = new();

	private readonly ObservableField<long> _value;

	private long _visualAmount;

	private int _visualAmountLocksCounter;

	#region StorageEntry

	public StorageEntry(T data,
		ObservableField<long> value)
	{
		Data = data;
		_value = value;

		_value.OnChanged += _ =>
		{
			OnAmountChanged?.Invoke(this);
			UpdateVisualAmount();
		};

		UpdateVisualAmount();
	}

	public long Amount => _value.Value;

	public long VisualAmount
	{
		get => _visualAmount;
		private set
		{
			_visualAmount = value;
			OnVisualAmountChanged?.Invoke(this);
		}
	}

	public void SetAmount(long amount)
	{
		_value.SetValue(amount);
	}

	public void LockVisualAmount()
	{
		_visualAmountLocksCounter++;
	}

	public void UnlockVisualAmount()
	{
		_visualAmountLocksCounter--;

		if (_visualAmountLocksCounter == 0)
		{
			UpdateVisualAmount();
		}
	}

	public StorageItemHolder HoldVisualAmount(long amount)
	{
		amount = Math.Min(amount, Amount);

		var holder = new StorageItemHolder
		{
			Amount = amount
		};

		_holders.AddLast(holder);
		UpdateVisualAmount();

		return holder;
	}

	public void ReleaseVisualAmount(StorageItemHolder holder)
	{
		if (_holders.Remove(holder))
		{
			UpdateVisualAmount();
		}
	}

	private void UpdateVisualAmount()
	{
		if (_visualAmountLocksCounter > 0)
		{
			return;
		}

		var amount = Amount;

		foreach (var holder in _holders)
		{
			amount -= holder.Amount;
		}

		VisualAmount = amount;
	}

	#endregion
}

}