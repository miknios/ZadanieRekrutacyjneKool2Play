using Zenject;

namespace ObjectPool
{
	public class PrefabPoolsInitializer : IInitializable
	{
		private PrefabPoolsConfig _prefabPoolsConfig;

		public PrefabPoolsInitializer(PrefabPoolsConfig prefabPoolsConfig)
		{
			_prefabPoolsConfig = prefabPoolsConfig;
		}
		
		public void Initialize()
		{
			foreach (var config in _prefabPoolsConfig.configs)
			{
				PrefabPool prefabPool = new PrefabPool(config.prefab, config.prewarm, config.poolIncreaseStep);
				PrefabPoolUtils.RegisterPool(prefabPool);
			}
		}
	}
}