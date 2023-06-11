namespace EM.GameKit
{

using System;
using System.Collections.Generic;

public sealed class Registers : IRegisters
{
	private readonly Dictionary<string, long> _registers = new();

	public event Action<string, long> OnChanged;

	#region IRegisters

	public long GetRegister(string key)
	{
		return _registers.TryGetValue(key, out var val) ? val : 0;
	}

	public void SetRegister(string key,
		long value)
	{
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