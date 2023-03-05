namespace EM.GameKit
{

public sealed class GdpRegulationModel
{
	#region GdpRegulationModel

	public bool IsAccepted { get; private set; }

	public void Accept()
	{
		IsAccepted = true;
	}

	#endregion
}

}