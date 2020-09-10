using System;
using UniRx;

namespace HealthAndDamage.POCO
{
	[Serializable]
	public class HealthPoints
	{
		private int _max;
		public ReactiveProperty<int> Amount;
		
		public HealthPoints(int max)
		{
			Amount = new ReactiveProperty<int>(0);
			_max = max;
		}

		public HealthPoints(int max, int initialHealth)
		{
			Amount = new ReactiveProperty<int>(initialHealth);
			_max = max;
		}

		public void DealDamage(int damage)
		{
			if(Amount.Value == 0)
				return;
			
			Amount.Value = Math.Max(Amount.Value - damage, 0);
		}

		public void Restore(int restoreAmount)
		{
			Amount.Value = Math.Min(Amount.Value + restoreAmount, _max);
		}

		public void ResetToMax()
		{
			Amount.Value = _max;
		}
	}
}