using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPool
{
	public class PrefabPool
	{
		private readonly IList<GameObject> _pool;
		private readonly int _poolIncreaseStep;
		private HashSet<GameObject> _spawned;
		private PrefabPoolSceneManager _prefabPoolSceneManager;
		public readonly GameObject Prefab;

		public PrefabPool(GameObject prefab, int prewarm = 10, int poolIncreaseStep = 5)
		{
			Prefab = prefab;
			_poolIncreaseStep = Mathf.Max(0, poolIncreaseStep);
			_pool = new List<GameObject>(prewarm);
			_spawned = new HashSet<GameObject>();
			_prefabPoolSceneManager = PrefabPoolSceneManager.Instance;

			ExtendPoolBy(prewarm);
		}

		private void ExtendPoolBy(int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				GameObject instantiated = Object.Instantiate(Prefab, _prefabPoolSceneManager.transform);
				instantiated.SetActive(false);
				_pool.Add(instantiated);
			}
		}

		public GameObject Spawn(Vector3 position, Quaternion rotation, Transform parent = null)
		{
			if (_pool.Count == 0)
				ExtendPoolBy(_poolIncreaseStep);

			GameObject spawned = _pool[0];
			Transform transform = spawned.transform;
			transform.position = position;
			transform.rotation = rotation;
			transform.SetParent(parent);
			spawned.SetActive(true);
			
			_pool.RemoveAt(0);

			return spawned;
		}

		public void Despawn(GameObject clone)
		{
			if(!_spawned.Contains(clone))
				return;

			_spawned.Remove(clone);
			clone.SetActive(false);
			clone.transform.SetParent(_prefabPoolSceneManager.transform);
			_pool.Add(clone);
		}
	}
}