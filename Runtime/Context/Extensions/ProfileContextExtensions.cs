namespace EM.GameKit
{

using BuildSystem;
using Foundation;
using Profile;

public static class ProfileContextExtensions
{
	public static Context BindProfile(this Context context)
	{
		var lifeTime = context.IsGlobalContext ? LifeTime.Global : LifeTime.Local;

		context.DiContainer
			.Bind<IStorageSegmentReceiverFactory>()
			.SetLifeTime(lifeTime)
			.To<StorageSegmentReceiverFactory>()
			.ToSingleton();

		context.DiContainer
			.Bind<JsonSerializeConfig>()
			.SetLifeTime(lifeTime)
			.To<JsonSerializeConfig>()
			.ToSingleton();

		context.DiContainer
			.Bind<IStorageSerializer>()
			.SetLifeTime(lifeTime)
			.To<JsonStorageSerializer>()
			.ToSingleton();

		context.DiContainer
			.Bind<IStorageLocation>()
			.SetLifeTime(lifeTime)
			.To<FileStorageLocation>()
			.ToSingleton();

		context.DiContainer
			.Bind<IVersionConfig>()
			.SetLifeTime(lifeTime)
			.ToFactory<VersionAddressableAssetFactory>()
			.ToSingleton();

		context.DiContainer
			.Bind<ISaveConfig>()
			.SetLifeTime(lifeTime)
			.ToFactory<SaveAddressableAssetFactory>()
			.ToSingleton();

		context.DiContainer
			.Bind<IProfile>()
			.SetLifeTime(lifeTime)
			.To<Profile>()
			.ToSingleton();

		return context;
	}
}

}