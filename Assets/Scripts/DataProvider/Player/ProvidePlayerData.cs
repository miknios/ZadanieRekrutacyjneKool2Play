using HealthAndDamage;
using Shooting.Guns.Components;
using UnityEngine;
using Zenject;

namespace DataProvider.Player
{
	public class ProvidePlayerData : MonoBehaviour
	{
		[SerializeField] private HealthComponent healthComponent = null;
		[SerializeField] private WeaponHandle weaponHandle = null;

		[Inject]
		public void ConstructWithInjection(PlayerDataProvider playerDataProvider)
		{
			playerDataProvider.Provide(healthComponent);
			playerDataProvider.Provide(weaponHandle);
		}
	}
}