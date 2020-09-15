using Cinemachine;
using DG.Tweening;
using Shooting.Bullets;
using UnityEngine;

namespace Shooting.Guns.Components
{
	public class Weapon : MonoBehaviour
	{
		private Transform _tip;
		private BulletSpawner _bulletSpawner;
		private float _fireRate;
		private float _spreadAngleHalf;
		private float _bulletsPerShot;
		private float _timeElapsedSinceLastShot;
		private bool _isReady;
		private Vector3 _initialScale;
		private CinemachineImpulseSource _impulseSource;

		public WeaponConfig Config { get; private set; }

		public void Initialize(WeaponConfig weaponConfig)
		{
			Config = weaponConfig;
			_tip = transform.GetComponentInChildren<GunTipTag>().transform;
			_bulletSpawner = new BulletSpawner(weaponConfig.bulletConfig, transform);
			_fireRate = weaponConfig.fireRate;
			_spreadAngleHalf = weaponConfig.spreadAngle / 2;
			_bulletsPerShot = weaponConfig.bulletsPerShot;
			_initialScale = transform.localScale;
			
		}

		public void AddImpulseSource(CinemachineImpulseSource impulseSource)
		{
			_impulseSource = impulseSource;
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
				AnimateWeaponActivation();
		}

		private void AnimateWeaponActivation()
		{
			DOTween.Sequence()
				.Append(transform.DOScale(_initialScale * 1.5f, 0.1f).From(Vector3.zero))
				.Append(transform.DOScale(_initialScale, 0.1f))
				.OnStart(() => _isReady = false)
				.OnComplete(() => _isReady = true);
		}

		public void Fire()
		{
			if(_timeElapsedSinceLastShot < _fireRate || !_isReady)
				return;

			_timeElapsedSinceLastShot = 0;
			_impulseSource?.GenerateImpulse();
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
}