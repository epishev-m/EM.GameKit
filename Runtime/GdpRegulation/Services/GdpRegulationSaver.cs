namespace EM.GameKit
{

using Profile;

public sealed class GdpRegulationSaver : IStorageSegmentSaver
{
	private readonly GdpRegulationModel _gdpRegulationModel;

	#region IStorageSegmentSaver

	IStorageSegment IStorageSegmentSaver.Save()
	{
		return new GdpRegulationStorageSegment
		{
			IsAccepted = _gdpRegulationModel.IsAccepted
		};
	}

	bool IStorageSegmentSaver.Load(IStorageSegment segment)
	{
		if (segment is not GdpRegulationStorageSegment storageSegment)
		{
			return false;
		}

		if (storageSegment.IsAccepted)
		{
			_gdpRegulationModel.Accept();
		}

		return true;
	}

	#endregion

	#region GdpRegulationSaver

	public GdpRegulationSaver(GdpRegulationModel gdpRegulationModel)
	{
		_gdpRegulationModel = gdpRegulationModel;
	}

	#endregion

	#region Nested

	[JsonSerialize("204B987E-5E72-44E8-9378-E9B366E6713A")]
	private sealed class GdpRegulationStorageSegment : IStorageSegment
	{
		public bool IsAccepted;
	}

	#endregion
}

}