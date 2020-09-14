using HealthAndDamage;
using UnityEngine;
using Zenject;

namespace DataProvider.Player
{
	public class ProvidePlayerData : MonoBehaviour
	{
		[SerializeField] private HealthComponent healthComponent = null;
		[SerializeField] private GunHandle gunHandle = null;

		[Inject]
		public void ConstructWithInjection(PlayerDataProvider playerDataProvider)
		{
			playerDataProvider.Provide(healthComponent);
			playerDataProvider.Provide(gunHandle);
		}
	}
}