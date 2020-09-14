using HealthAndDamage;

namespace DataProvider.Player
{
	public class PlayerDataProvider
	{
		public HealthDataProvider HealthDataProvider { get; } = new HealthDataProvider();
		public ActiveWeaponConfigDataProvider WeaponConfigProvider { get; } = new ActiveWeaponConfigDataProvider();

		public void Provide(IHealthData healthData)
		{
			HealthDataProvider.Provide(healthData);
		}

		public void Provide(IActiveWeaponData activeWeaponData)
		{
			WeaponConfigProvider.Provide(activeWeaponData);
		}
	}
}