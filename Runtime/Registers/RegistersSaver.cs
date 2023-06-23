namespace EM.GameKit
{

using System.Collections.Generic;
using Profile;

public class RegistersSaver : IStorageSegmentSaver
{
	private readonly IRegisters _registers;

	#region IStorageSegmentSaver

	public IProfileStorageSegment Save()
	{
		return new RegistersProfileStorageSegment()
		{
			Refisters = new Dictionary<string, long>(_registers.GetAll())
		};
	}

	public bool Load(IProfileStorageSegment segment)
	{
		if (segment is not RegistersProfileStorageSegment storageSegment)
		{
			return false;
		}

		_registers.Update(storageSegment.Refisters);

		return true;
	}

	#endregion
	
	#region QuestsSaver

	public RegistersSaver(IRegisters registers)
	{
		_registers = registers;
	}

	#endregion

	#region Nested

	[JsonSerialize("CE87304C-2D75-481E-9600-B5B9B9183676")]
	private sealed class RegistersProfileStorageSegment : IProfileStorageSegment
	{
		public Dictionary<string, long> Refisters;
	}

	#endregion
}

}