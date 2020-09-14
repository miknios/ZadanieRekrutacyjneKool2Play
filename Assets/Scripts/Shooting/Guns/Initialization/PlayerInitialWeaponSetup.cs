using System.Collections.Generic;
using UnityEngine;

namespace Shooting.Guns.Initialization
{
	[CreateAssetMenu(menuName = "Create PlayerInitialWeaponSetup", fileName = "PlayerInitialWeaponSetup", order = 0)]
	public class PlayerInitialWeaponSetup : ScriptableObject
	{
		public List<WeaponConfig> Weapons;
	}
}