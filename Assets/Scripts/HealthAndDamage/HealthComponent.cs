using HealthAndDamage.POCO;
using UniRx;
using UnityEngine;

namespace HealthAndDamage
{
	public class HealthComponent : MonoBehaviour, IDamageable, IHealthData
	{
		[SerializeField] private int maxHealth = 100;
		[SerializeField] private int initialHealth = 100;

		private Health _health;
		
		public ReactiveProperty<int> Current => _health.Current;
		public ReactiveProperty<int> Max => _health.Max;

		private void Awake()
		{
			_health = new Health(maxHealth, initialHealth);
		}

		public void DealDamage(int value)
		{
			_health.DealDamage(value);
		}
	}
}