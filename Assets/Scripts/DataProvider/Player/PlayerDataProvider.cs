using HealthAndDamage.POCO;

namespace DataProvider.Player
{
	public class PlayerDataProvider
	{
		public HealthDataProvider HealthDataProvider { get; } = new HealthDataProvider();

		public void Provide(IHealthData healthData)
		{
			HealthDataProvider.Provide(healthData);
		}
	}
}