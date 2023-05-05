namespace EM.GameKit
{

using Foundation;
using UI;

public static class UiSystemContextExtensions
{
	public static Context BindUiSystem(this Context context)
	{
		var lifeTime = context.IsGlobalContext ? LifeTime.Global : LifeTime.Local;
		
		context.DiContainer
			.Bind<IUiSystem>()
			.SetLifeTime(lifeTime)
			.To<UiSystem>()
			.ToSingleton();

		return context;
	}
}

}