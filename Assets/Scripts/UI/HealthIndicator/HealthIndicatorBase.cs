using DataProvider.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.HealthIndicator
{
	public abstract class HealthIndicatorBase : MonoBehaviour
	{
		private PlayerDataProvider _playerDataProvider;
		private int currentHealth;
		private int maxHealth;

		[Inject]
		public void ConstructWithInjection(PlayerDataProvider playerDataProvider)
		{
			_playerDataProvider = playerDataProvider;
		}

		private void Start()
		{
			_playerDataProvider.HealthDataProvider.GetData().Current.Subscribe(UpdateCurrentHealth);
			_playerDataProvider.HealthDataProvider.GetData().Max.Subscribe(UpdateMaxHealth);
		}
	
		private void UpdateCurrentHealth(int currentHealth)
		{
			this.currentHealth = currentHealth;
			UpdateIndicator(currentHealth, maxHealth);
		}
	
		private void UpdateMaxHealth(int maxHealth)
		{
			this.maxHealth = maxHealth;
			UpdateIndicator(currentHealth, maxHealth);
		}
	
		protected abstract void UpdateIndicator(int currentHealth, int maxHealth);
	}
}