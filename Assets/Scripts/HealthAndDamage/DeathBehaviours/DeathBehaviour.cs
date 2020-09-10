using HealthAndDamage.MonoBehaviour;
using UniRx;
using UnityEngine;

namespace HealthAndDamage.DeathBehaviours
{
	[RequireComponent(typeof(Health))]
	public abstract class DeathBehaviour : UnityEngine.MonoBehaviour
	{
		protected Health health;

		public void Awake()
		{
			health = GetComponent<Health>();
		}

		private void Start()
		{
			health.healthPoints.Amount
				.Where(amount => amount == 0)
				.Subscribe(_ => OnDeath());
		}

		protected abstract void OnDeath();
	}
}