using UniRx;
using UnityEngine;

namespace Shooting
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody = null;
	
		public void Fire(float bulletSpeed)
		{
			Observable.EveryUpdate()
				.Subscribe(_ => MoveBullet(bulletSpeed));
		}

		private void MoveBullet(float bulletSpeed)
		{
			_rigidbody?.MovePosition(transform.position + transform.forward * bulletSpeed * Time.deltaTime);
		}
	}
}