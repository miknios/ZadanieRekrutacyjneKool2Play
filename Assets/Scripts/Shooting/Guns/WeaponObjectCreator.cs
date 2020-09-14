using Shooting.Guns.Components;
using UnityEngine;

namespace Shooting.Guns
{
	public static class WeaponObjectCreator
	{
		public static Weapon Create(WeaponConfig weaponConfig)
		{
			GameObject weaponObject = Object.Instantiate(weaponConfig.model);
			Weapon weapon = weaponObject.AddComponent<Weapon>();
			weapon.Initialize(weaponConfig);

			return weapon;
		}
	}
}