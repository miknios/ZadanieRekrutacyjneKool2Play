using HealthAndDamage;
using UniRx;
using UnityEngine;

public class ProjectileBullet : BulletBase
{
	[SerializeField] private Rigidbody _rigidbody;
	
	private float _distanceTraveled;

	public override void Initialize(BulletConfig bulletConfig)
	{
		base.Initialize(bulletConfig);
		InitializeRigidbody();
		InitializeDamageDealer();
	}

	private void InitializeRigidbody()
	{
		_rigidbody = gameObject.AddComponent<Rigidbody>();
		_rigidbody.isKinematic = true;
		_rigidbody.useGravity = false;
	}

	// TODO: get callback on damage dealt from damage dealer -> destroy if not penetrable
	private void InitializeDamageDealer()
	{
		DamageDealer damageDealer = gameObject.AddComponent<DamageDealer>();
		damageDealer.Initialize(Damage, DamageDealFrequency);
	}

	protected override void DoFire(Vector3 direction)
	{
		_distanceTraveled = 0;
		
		Observable.EveryUpdate()
			.TakeUntilDisable(gameObject)
			.Subscribe(_ => Move(direction));
	}

	private void Move(Vector3 direction)
	{
		Vector3 moveStepVector = direction.normalized * Speed * Time.deltaTime;
		_rigidbody?.MovePosition(transform.position + moveStepVector);
		_distanceTraveled += moveStepVector.magnitude;

		if (_distanceTraveled >= Range)
			Destroy();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(!Penetrable)
			Destroy();
	}
}