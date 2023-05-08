namespace EM.GameKit
{

using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;
using UI;

public static class UiSystemContextExtensions
{
	public static Context AddUiSystem(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Bind<IViewModelFactory>()
			.SetLifeTime(lifeTime)
			.To<ViewModelFactory>()
			.ToSingleton();

		context.DiContainer
			.Bind<IUiSystem>()
			.SetLifeTime(lifeTime)
			.To<UiSystem>()
			.ToSingleton();

		return context;
	}

	public static Context UseUiSystem(this Context context,
		string id)
	{
		context.DiContainer
			.Resolve<IUiSystem>()
			.CreateUiRootAsync(id);

		return context;
	}

	public static Context ReleaseUiSystem(this Context context)
	{
		var lifeTime = context.IsGlobalContext
			? LifeTime.Global
			: LifeTime.Local;

		context.DiContainer
			.Resolve<IUiSystem>()
			.Unload(lifeTime);

		return context;
	}
}

}