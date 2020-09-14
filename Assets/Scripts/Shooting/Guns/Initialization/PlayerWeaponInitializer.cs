using Shooting.Guns.Components;
using UnityEngine;

namespace Shooting.Guns.Initialization
{
	[RequireComponent(typeof(WeaponHandle))]
	public class PlayerWeaponInitializer : MonoBehaviour
	{
		[SerializeField] private PlayerInitialWeaponSetup playerInitialWeaponSetup = null;
	
		private void Awake()
		{
			WeaponHandle weaponHandle = GetComponent<WeaponHandle>();
			foreach (var weaponConfig in playerInitialWeaponSetup.Weapons)
			{
				Weapon newWeapon = WeaponObjectCreator.Create(weaponConfig);
				weaponHandle.AttachNewWeapon(newWeapon);
			}

			weaponHandle.Initialize();
		}
	}
}