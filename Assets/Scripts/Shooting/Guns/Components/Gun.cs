using DG.Tweening;
using UnityEngine;

public class Gun : MonoBehaviour
{
	private Transform _tip;
	private BulletSpawner _bulletSpawner;
	private float fireRate;
	private float spreadAngleHalf;
	private float bulletsPerShot;
	private float timeElapsedSinceLastShot;
	private bool isReady;
	private Vector3 initialScale;

	public GunConfig Config { get; private set; }

	public void Initialize(GunConfig gunConfig)
	{
		Config = gunConfig;
		_tip = transform.GetComponentInChildren<GunTipTag>().transform;
		_bulletSpawner = new BulletSpawner(gunConfig.bulletConfig, transform);
		fireRate = gunConfig.fireRate;
		spreadAngleHalf = gunConfig.spreadAngle / 2;
		bulletsPerShot = gunConfig.bulletsPerShot;
		initialScale = transform.localScale;
	}

	private void Update()
	{
		timeElapsedSinceLastShot += Time.deltaTime;
	}

	public void SetActive(bool active)
	{
		gameObject.SetActive(active);
		
		if (active)
		{
			DOTween.Sequence()
				.Append(transform.DOScale(initialScale * 1.5f, 0.1f).From(Vector3.zero))
				.Append(transform.DOScale(initialScale, 0.1f))
				.OnStart(() => isReady = false)
				.OnComplete(() => isReady = true);
		}
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