using HealthAndDamage.POCO;

namespace DataProvider.Player
{
	public class PlayerDataProvider
	{
		public HealthDataProvider HealthDataProvider { get; } = new HealthDataProvider();
		public ActiveGunConfigDataProvider GunConfigProvider { get; } = new ActiveGunConfigDataProvider();

		public void Provide(IHealthData healthData)
		{
			HealthDataProvider.Provide(healthData);
		}

		public void Provide(IActiveGunData activeGunData)
		{
			GunConfigProvider.Provide(activeGunData);
		}
	}
}