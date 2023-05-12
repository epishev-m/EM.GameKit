namespace EM.GameKit
{

public interface ICheatFactory
{
	ICheat Get<TCheat>()
		where TCheat : class, ICheat;
}

}