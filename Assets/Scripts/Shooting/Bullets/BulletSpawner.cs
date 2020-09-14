using ObjectPool;
using Shooting.Bullets.Components;
using UnityEngine;

namespace Shooting.Bullets
{
	public class BulletSpawner
	{
		private readonly PrefabPool _pool;

		public BulletSpawner(BulletConfig config, Transform inactiveBulletParent)
		{
			GameObject bulletBlueprintObject = BulletObjectCreator.Create(config);
			BulletBase bullet = bulletBlueprintObject.GetComponent<BulletBase>();
			bullet.Initialize(config);
			_pool = new PrefabPool(bulletBlueprintObject, inactiveBulletParent, config.poolPrewarm,
				config.poolIncreaseStep);
		
			bulletBlueprintObject.SetActive(false);
		
		}

		public void Spawn(Vector3 origin, Vector3 direction)
		{
			GameObject bulletObject = _pool.Spawn(origin, Quaternion.identity);
			BulletBase bullet = bulletObject.GetComponent<BulletBase>();
			bullet.Fire(direction, _pool);
		}
	}
}