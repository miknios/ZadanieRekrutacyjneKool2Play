using Shooting.Bullets.Components;
using UnityEngine;

namespace Shooting.Bullets
{
	public static class BulletObjectCreator
	{
		public static GameObject Create(BulletConfig config)
		{
			GameObject bulletObject = new GameObject("Bullet");
			bulletObject.hideFlags = HideFlags.HideInHierarchy;
			AddConcreteBulletComponent(bulletObject, config.bulletType);

			return bulletObject;
		}

		private static void AddConcreteBulletComponent(GameObject bulletObject, BulletType bulletType)
		{
			switch (bulletType)
			{
				case BulletType.Projectile:
					bulletObject.AddComponent<ProjectileBullet>();
					break;
				case BulletType.Hitscan:
					bulletObject.AddComponent<HitscanBullet>();
					break;
				default:
					Debug.LogError("Couldn't find matching bullet component for bullet type.");
					break;
			}
		}
	}
}