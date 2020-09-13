using UnityEngine;

public class Gun : MonoBehaviour
{
	private Transform _tip;
	private BulletSpawner _bulletSpawner;
	private float fireRate;
	private float spreadAngle;
	private float bulletsPerShot;

	public void Initialize(GunConfig gunConfig)
	{
		_tip = transform.GetComponentInChildren<GunTipTag>().transform;
		_bulletSpawner = new BulletSpawner(gunConfig.bulletConfig, transform);
		fireRate = gunConfig.fireRate;
		spreadAngle = gunConfig.spreadAngle;
		bulletsPerShot = gunConfig.bulletsPerShot;
	}

	
	// TODO: some kind of tween?
	public void SetActive(bool active)
	{
		gameObject.SetActive(active);
	}

	public void Fire()
	{
		for (int i = 0; i < bulletsPerShot; i++)
		{
			Vector3 shotDirection = GetDirectionWithinAngle();
			_bulletSpawner.Spawn(_tip.position, shotDirection);
		}
	}

	// TODO: use spreadAngle to get random direction
	private Vector3 GetDirectionWithinAngle()
	{
		return transform.forward;
	}
}