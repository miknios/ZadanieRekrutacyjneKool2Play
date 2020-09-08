using System;

namespace HealthAndDamage.POCO
{
	[Serializable]
	public class HealthPoints
	{
		private int _amount;
		private int _max;

		public event Action DamageDealt;
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
			if(_amount == 0)
				return;
			
			_amount = Math.Max(_amount - damage, 0);
			DamageDealt?.Invoke();
			
			if(_amount == 0)
				HealthDepleted?.Invoke();
		}

		public void Restore(int restoreAmount)
		{
			_amount = Math.Min(_amount + restoreAmount, _max);
		}

		public void ResetToMax()
		{
			_amount = _max;
		}
	}
}