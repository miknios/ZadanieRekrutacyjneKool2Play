using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
	public static class PrefabPoolUtils
	{
		private static IDictionary<GameObject, PrefabPool> _poolForPrefab = new Dictionary<GameObject, PrefabPool>();

		public static void RegisterPool(PrefabPool prefabPool)
		{
			if(_poolForPrefab.ContainsKey(prefabPool.Prefab))
				Debug.LogWarning("Pool for provided prefab is already registered.");
			
			_poolForPrefab[prefabPool.Prefab] = prefabPool;
		}

		public static PrefabPool PoolForPrefab(GameObject prefab)
		{
			if (!_poolForPrefab.TryGetValue(prefab, out var pool))
			{
				pool = new PrefabPool(prefab);
				RegisterPool(pool);
			}
			
			return pool;
		}
	}
}