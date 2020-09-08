using UnityEngine;

namespace HealthAndDamage.MonoBehaviour
{
	public class Health : UnityEngine.MonoBehaviour, IDamageable
	{
		[SerializeField] private int maxHealth = 100;
		[SerializeField] private int initialHealth = 100;

		public POCO.HealthPoints healthPoints;

		private void Awake()
		{
			healthPoints = new POCO.HealthPoints(maxHealth, initialHealth);
		}

		public void DealDamage(int value)
		{
			healthPoints.DealDamage(value);
		}
	}
}