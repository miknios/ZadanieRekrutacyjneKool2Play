using HealthAndDamage.MonoBehaviour;
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
			health.healthPoints.HealthDepleted += OnDeath;
		}

		protected abstract void OnDeath();
	}
}