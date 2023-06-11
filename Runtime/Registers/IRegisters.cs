namespace EM.GameKit
{

using System;

public interface IRegisters
{
	event Action<string, long> OnChanged;

	long GetRegister(string key);

	void SetRegister(string key,
		long value);

	long AddRegister(string key,
		long delta);
}

}