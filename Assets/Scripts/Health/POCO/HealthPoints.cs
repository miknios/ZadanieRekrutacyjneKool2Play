using System;
using UnityEngine;

namespace Health.POCO
{
	[Serializable]
	public class HealthPoints
	{
		private int _amount;
		private int _max;

		public event Action HealthDepleted;

		public HealthPoints(int max)
		{
			_max = max;
		}

		public HealthPoints(int max, int initialHealth)
		{
			_max = max;
			_amount = initialHealth;
		}

		public void DealDamage(int damage)
		{
			_amount = Mathf.Max(_amount - damage, 0);
			
			if(_amount == 0)
				HealthDepleted?.Invoke();
		}

		public void Restore(int restoreAmount)
		{
			_amount = Mathf.Min(_amount + restoreAmount, _max);
		}

		public void ResetToMax()
		{
			_amount = _max;
		}
	}
}