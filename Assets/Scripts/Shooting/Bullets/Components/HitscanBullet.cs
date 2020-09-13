using HealthAndDamage;
using UnityEngine;

public class HitscanBullet : BulletBase
{
	// TODO: include penetrable case
	protected override void DoFire(Vector3 direction)
	{
		if (!Physics.Raycast(transform.position, direction, out var hitInfo, Range))
			return;

		if (!hitInfo.collider.gameObject.TryGetComponent<IDamageable>(out var damageable))
			return;

		damageable.DealDamage(Damage);
		Destroy();
	}
}