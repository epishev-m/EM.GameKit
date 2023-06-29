namespace EM.GameKit
{

using UI;

public abstract class BaseHintTooltipViewModel : ViewModel<IHintTooltipData>
{
	public abstract string Message { get; }

	public abstract void Finish();
}

}