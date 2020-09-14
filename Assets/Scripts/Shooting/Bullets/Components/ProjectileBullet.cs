using HealthAndDamage;
using UniRx;
using UnityEngine;

namespace Shooting.Bullets.Components
{
	public class ProjectileBullet : BulletBase
	{
		[SerializeField] private Rigidbody _rigidbody;
	
		private float _distanceTraveled;

		public override void Initialize(BulletConfig bulletConfig)
		{
			base.Initialize(bulletConfig);
			InitializeModel(bulletConfig);
			InitializeRigidbody();
			InitializeDamageDealer();
		}

		private void InitializeModel(BulletConfig bulletConfig)
		{
			var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.transform.SetParent(transform);
			sphere.transform.position = Vector3.zero;
			sphere.transform.localScale = Vector3.one * bulletConfig.scale;
			sphere.GetComponent<Renderer>().material = bulletConfig.material;
		}

		private void InitializeRigidbody()
		{
			_rigidbody = gameObject.AddComponent<Rigidbody>();
			_rigidbody.isKinematic = true;
			_rigidbody.useGravity = false;
		}

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
}