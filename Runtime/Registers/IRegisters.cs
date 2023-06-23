namespace EM.GameKit
{

using System;
using System.Collections.Generic;

public interface IRegisters
{
	event Action<string, long> OnChanged;

	IReadOnlyDictionary<string, long> GetAll();

	void Update(IReadOnlyDictionary<string, long> data);

	long GetRegister(string key);

	void SetRegister(string key,
		long value);

	long AddRegister(string key,
		long delta);
}

}