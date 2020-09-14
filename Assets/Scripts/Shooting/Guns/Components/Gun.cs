using DG.Tweening;
using UnityEngine;

public class Gun : MonoBehaviour
{
	private Transform _tip;
	private BulletSpawner _bulletSpawner;
	private float _fireRate;
	private float _spreadAngleHalf;
	private float _bulletsPerShot;
	private float _timeElapsedSinceLastShot;
	private bool _isReady;
	private Vector3 _initialScale;

	public GunConfig Config { get; private set; }

	public void Initialize(GunConfig gunConfig)
	{
		Config = gunConfig;
		_tip = transform.GetComponentInChildren<GunTipTag>().transform;
		_bulletSpawner = new BulletSpawner(gunConfig.bulletConfig, transform);
		_fireRate = gunConfig.fireRate;
		_spreadAngleHalf = gunConfig.spreadAngle / 2;
		_bulletsPerShot = gunConfig.bulletsPerShot;
		_initialScale = transform.localScale;
	}

	private void Update()
	{
		_timeElapsedSinceLastShot += Time.deltaTime;
	}

	public void SetActive(bool active)
	{
		gameObject.SetActive(active);

		transform.DOKill();
		if (active)
		{
			DOTween.Sequence()
				.Append(transform.DOScale(_initialScale * 1.5f, 0.1f).From(Vector3.zero))
				.Append(transform.DOScale(_initialScale, 0.1f))
				.OnStart(() => _isReady = false)
				.OnComplete(() => _isReady = true);
		}
	}

	public void Fire()
	{
		if(_timeElapsedSinceLastShot < _fireRate || !_isReady)
			return;

		_timeElapsedSinceLastShot = 0;
		AnimateFire();
		SpawnBullets();
	}

	private void AnimateFire()
	{
		DOTween.Sequence()
			.Append(transform.DOLocalMoveZ(0, 0))
			.Append(transform.DOLocalMoveZ(-0.2f, 0.05f).SetRelative(true))
			.AppendInterval(_fireRate - 0.05f)
			.Append(transform.DOLocalMoveZ(0.2f, 0.05f).SetRelative(true));
	}

	private void SpawnBullets()
	{
		for (int i = 0; i < _bulletsPerShot; i++)
			SpawnBullet();
	}

	private void SpawnBullet()
	{
		Vector3 shotDirection = GetDirectionWithinAngle();
		_bulletSpawner.Spawn(_tip.position, shotDirection);
	}

	private Vector3 GetDirectionWithinAngle()
	{
		float randomAngle = Random.Range(-_spreadAngleHalf, _spreadAngleHalf);
		Quaternion rotation = Quaternion.AngleAxis(randomAngle, Vector3.up);
		
		return rotation * transform.forward;
	}
}