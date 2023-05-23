namespace EM.GameKit
{

using Profile;

public sealed class GdpRegulationSaver : IStorageSegmentSaver
{
	private readonly GdpRegulationModel _gdpRegulationModel;

	#region IStorageSegmentSaver

	IProfileStorageSegment IStorageSegmentSaver.Save()
	{
		return new GdpRegulationProfileStorageSegment
		{
			IsAccepted = _gdpRegulationModel.IsAccepted
		};
	}

	bool IStorageSegmentSaver.Load(IProfileStorageSegment segment)
	{
		if (segment is not GdpRegulationProfileStorageSegment storageSegment)
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
	private sealed class GdpRegulationProfileStorageSegment : IProfileStorageSegment
	{
		public bool IsAccepted;
	}

	#endregion
}

}