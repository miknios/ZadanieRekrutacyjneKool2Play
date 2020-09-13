using UnityEngine;

public static class GunObjectCreator
{
	public static Gun Create(GunConfig gunConfig)
	{
		GameObject gunObject = Object.Instantiate(gunConfig.model);
		Gun gun = gunObject.AddComponent<Gun>();
		gun.Initialize(gunConfig);

		return gun;
	}
}