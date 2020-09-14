using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
	[CreateAssetMenu(fileName = "PrefabPoolsConfig", menuName = "PrefabPool/PrefabPoolsConfig")]
	public class PrefabPoolsConfig : ScriptableObject
	{
		public List<PrefabPoolConfigData> configs;
	}
	
	[Serializable]
	public class PrefabPoolConfigData
	{
		public GameObject prefab;
		public int prewarm;
		public int poolIncreaseStep;
	}
}