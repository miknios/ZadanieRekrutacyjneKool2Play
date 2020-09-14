using UnityEngine;

namespace ObjectPool
{
	public class PrefabPoolSceneContainer : MonoBehaviour
	{
		[SerializeField] private PrefabPoolsConfig poolsConfig = null;

		private void Start()
		{
			foreach (var config in poolsConfig.configs)
			{
				PrefabPool prefabPool =
					new PrefabPool(config.prefab, transform, config.prewarm, config.poolIncreaseStep);
				PrefabPoolUtils.RegisterPool(prefabPool);
			}
		}
	}
}