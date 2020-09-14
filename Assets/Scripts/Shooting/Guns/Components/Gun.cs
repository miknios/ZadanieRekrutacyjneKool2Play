using UnityEngine;

public class Gun : MonoBehaviour
{
	private Transform _tip;
	private BulletSpawner _bulletSpawner;
	private float fireRate;
	private float spreadAngleHalf;
	private float bulletsPerShot;
	private float timeElapsedSinceLastShot;

	public GunConfig Config { get; private set; }

	public void Initialize(GunConfig gunConfig)
	{
		Config = gunConfig;
		_tip = transform.GetComponentInChildren<GunTipTag>().transform;
		_bulletSpawner = new BulletSpawner(gunConfig.bulletConfig, transform);
		fireRate = gunConfig.fireRate;
		spreadAngleHalf = gunConfig.spreadAngle / 2;
		bulletsPerShot = gunConfig.bulletsPerShot;
	}

	private void Update()
	{
		timeElapsedSinceLastShot += Time.deltaTime;
	}

	// TODO: some kind of tween?
	public void SetActive(bool active)
	{
		gameObject.SetActive(active);
	}

	public void Fire()
	{
		if(timeElapsedSinceLastShot < fireRate)
			return;

		timeElapsedSinceLastShot = 0;
		for (int i = 0; i < bulletsPerShot; i++)
		{
			Vector3 shotDirection = GetDirectionWithinAngle();
			_bulletSpawner.Spawn(_tip.position, shotDirection);
		}
	}

	private Vector3 GetDirectionWithinAngle()
	{
		float randomAngle = Random.Range(-spreadAngleHalf, spreadAngleHalf);
		Quaternion rotation = Quaternion.AngleAxis(randomAngle, Vector3.up);
		
		return rotation * transform.forward;
	}
}