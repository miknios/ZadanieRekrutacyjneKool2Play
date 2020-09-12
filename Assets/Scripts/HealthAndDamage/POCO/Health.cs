using System;
using UniRx;

namespace HealthAndDamage.POCO
{
	public interface IHealthData
	{
		ReactiveProperty<int> Max { get; }
		ReactiveProperty<int> Current { get; }
	}
	
	[Serializable]
	public class Health : IHealthData
	{
		public ReactiveProperty<int> Max { get; }
		public ReactiveProperty<int> Current { get; }

		public Health(int max)
		{
			Max = new ReactiveProperty<int>(max);
			Current = new ReactiveProperty<int>(0);
		}

		public Health(int max, int initialHealth)
		{
			Max = new ReactiveProperty<int>(max);
			Current = new ReactiveProperty<int>(initialHealth);
		}

		public void DealDamage(int damage)
		{
			if(Current.Value == 0)
				return;
			
			Current.Value = Math.Max(Current.Value - damage, 0);
		}

		public void Restore(int restoreAmount)
		{
			Current.Value = Math.Min(Current.Value + restoreAmount, Max.Value);
		}

		public void ResetToMax()
		{
			Current.Value = Max.Value;
		}
	}
	
	public class NullHealthData : IHealthData
	{
		public ReactiveProperty<int> Max { get; }
		public ReactiveProperty<int> Current { get; }

		public NullHealthData()
		{
			Max = new ReactiveProperty<int>(0);
			Current = Max;
		}
	}
}