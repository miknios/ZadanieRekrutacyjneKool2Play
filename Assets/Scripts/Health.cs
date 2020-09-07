using DefaultNamespace;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private int initialHealth = 100;

	public HealthPoints healthPoints;

	private void Awake()
	{
		healthPoints = new HealthPoints(maxHealth, initialHealth);
	}

	public void DealDamage(int value)
	{
		healthPoints.DealDamage(value);
	}
}