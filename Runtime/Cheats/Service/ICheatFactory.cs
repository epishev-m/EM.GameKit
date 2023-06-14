namespace EM.GameKit
{

using Foundation;

public interface ICheatFactory
{
	Result<ICheat> Get<TCheat>()
		where TCheat : class, ICheat;
}

}