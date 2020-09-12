using System;
using ObjectPool;
using UniRx;
using UnityEngine;

namespace Shooting
{
	public class Gun : MonoBehaviour
	{
		[SerializeField] private GameObject bulletPrefab = null;
		[SerializeField] private float bulletSpeed = 5f;
		[SerializeField] private float fireRate = 0.125f;
	
		private PrefabPool _bulletPool;

		private void Awake()
		{

			// TODO: extract input for config
			var inputStream = Observable.EveryUpdate()
				.Where(_ => Input.GetMouseButtonDown(0))
				.ThrottleFirst(TimeSpan.FromSeconds(fireRate));

			inputStream.Subscribe(_ => ShootBullet());
		}

		private void Start()
		{
			_bulletPool = PrefabPoolUtils.PoolForPrefab(bulletPrefab);
		}

		private void ShootBullet()
		{
			var bulletObject = _bulletPool.Spawn(transform.position, transform.rotation);
			bulletObject.layer = gameObject.layer;
			var bullet = bulletObject.GetComponent<Bullet>();
			bullet.Fire(bulletSpeed);
		}
	}
}