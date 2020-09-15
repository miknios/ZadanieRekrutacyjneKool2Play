using Shooting.Bullets;
using UnityEngine;

namespace Shooting.Guns
{
	[CreateAssetMenu(menuName = "Create WeaponConfig", fileName = "WeaponConfig", order = 0)]
	public class WeaponConfig : ScriptableObject
	{
		public BulletConfig bulletConfig;
		public float fireRate;
		public float spreadAngle;
		public int bulletsPerShot;
		public GameObject model;
		public Sprite icon;
		public float visualImpact;
	}
}