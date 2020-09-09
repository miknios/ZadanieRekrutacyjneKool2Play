using UnityEngine;
using Zenject;

namespace ObjectPool
{
	public class PrefabPoolsInstaller : MonoInstaller
	{
		[SerializeField] private PrefabPoolsConfig _prefabPoolsConfig = null;

		public override void InstallBindings()
		{
			Container.BindInstance(_prefabPoolsConfig);
			Container.BindInterfacesTo<PrefabPoolsInitializer>().AsSingle().NonLazy();
		}
	}
}