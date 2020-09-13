using UnityEngine;

public static class BulletObjectCreator
{
	public static GameObject Create(BulletConfig config)
	{
		GameObject bulletObject = new GameObject("Bullet");
		bulletObject.hideFlags = HideFlags.HideInHierarchy;
		ConfigureConcreteBullet(bulletObject, config);

		return bulletObject;
	}

	private static void ConfigureConcreteBullet(GameObject bulletObject, BulletConfig config)
	{
		switch (config.bulletType)
		{
			case BulletType.Projectile:
				bulletObject.AddComponent<ProjectileBullet>();
				var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				sphere.transform.SetParent(bulletObject.transform);
				sphere.transform.position = Vector3.zero;
				sphere.transform.localScale = Vector3.one * config.scale;
				sphere.GetComponent<Renderer>().material = config.material;
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