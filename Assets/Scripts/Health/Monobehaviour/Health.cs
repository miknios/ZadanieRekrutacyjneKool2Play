﻿using Health.POCO;
using UnityEngine;

namespace Health.MonoBehaviour
{
	public class Health : UnityEngine.MonoBehaviour, IDamageable
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
}