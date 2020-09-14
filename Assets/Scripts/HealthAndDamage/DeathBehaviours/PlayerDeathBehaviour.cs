using Enemy;
using Zenject;

namespace HealthAndDamage.DeathBehaviours
{
	public class PlayerDeathBehaviour : DeathBehaviour
	{
		private IEnemyTargetRegistry _enemyTargetRegistry;

		[Inject]
		public void Initialize(IEnemyTargetRegistry enemyTargetRegistry)
		{
			_enemyTargetRegistry = enemyTargetRegistry;
		}
		
		// TODO: invoke game over
		protected override void OnDeath()
		{
			_enemyTargetRegistry.Unregister(transform);
			Destroy(gameObject);
		}
	}
}