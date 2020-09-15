using UniRx;
using UnityEngine;

namespace HealthAndDamage.DeathBehaviours
{
	[RequireComponent(typeof(HealthComponent))]
	public abstract class DeathBehaviour : MonoBehaviour
	{
		private IHealthData _healthData;

		public void Awake()
		{
			_healthData = GetComponent<IHealthData>();
		}

		private void Start()
		{
			_healthData.Current
				.Where(amount => amount == 0)
				.Subscribe(_ => OnDeath());

			OnStart();
		}

		protected virtual void OnStart()
		{
		}

		protected abstract void OnDeath();
	}
}