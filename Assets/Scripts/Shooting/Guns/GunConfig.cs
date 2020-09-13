using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Create GunConfig", fileName = "GunConfig", order = 0)]
public class GunConfig : ScriptableObject
{
	public BulletConfig bulletConfig;
	public float fireRate;
	[FormerlySerializedAs("spread")] public float spreadAngle;
	public int bulletsPerShot;
	public GameObject model;
}