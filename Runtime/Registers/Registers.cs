namespace EM.GameKit
{

using System;
using System.Collections.Generic;

public sealed class Registers : IRegisters
{
	private readonly Dictionary<string, long> _registers = new();

	public event Action<string, long> OnChanged;

	#region IRegisters

	public IReadOnlyDictionary<string, long> GetAll() => _registers;

	public void Update(IReadOnlyDictionary<string, long> data)
	{
		_registers.Clear();

		foreach (var pair in data)
		{
			_registers.Add(pair.Key, pair.Value);
		}
	}

	public long GetRegister(string key)
	{
		return _registers.TryGetValue(key, out var val) ? val : 0;
	}

	public void SetRegister(string key,
		long value)
	{
		if (value < 0)
		{
			value = 0;
		}

		_registers[key] = value;
		OnChanged?.Invoke(key, value);
	}

	public long AddRegister(string key,
		long delta)
	{
		var value = GetRegister(key);
		value += delta;
		SetRegister(key, value);

		return value;
	}

	#endregion
}

}