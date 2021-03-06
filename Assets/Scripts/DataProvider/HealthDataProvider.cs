﻿using HealthAndDamage;

namespace DataProvider
{
	public class HealthDataProvider : DataProvider<IHealthData>
	{
		protected override IHealthData NullDataProvider { get; } = new NullHealthData();
	}
}