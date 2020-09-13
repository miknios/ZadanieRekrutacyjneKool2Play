using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create PlayerInitialGunSetup", fileName = "PlayerInitialGunSetup", order = 0)]
public class PlayerInitialGunSetup : ScriptableObject
{
	public List<GunConfig> Guns;
}