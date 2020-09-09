using UnityEngine;

namespace ObjectPool
{
	public class PrefabPoolSceneManager : MonoBehaviour
	{
		private static PrefabPoolSceneManager _instance;

		public static PrefabPoolSceneManager Instance => _instance ? _instance : CreateManager();

		private static PrefabPoolSceneManager CreateManager()
		{
			GameObject gameObject = new GameObject(nameof(PrefabPoolSceneManager));
			return gameObject.AddComponent<PrefabPoolSceneManager>();
		}

		private void Awake()
		{
			EnsureUniqueInstance();
			DontDestroyOnLoad(this);
		}

		private void EnsureUniqueInstance()
		{
			if (_instance != null)
				Destroy(this);

			_instance = this;
		}
	}
}