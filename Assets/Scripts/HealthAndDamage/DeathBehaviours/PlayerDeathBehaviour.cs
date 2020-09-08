using Enemy.TargetFollowing;
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
		
		// TODO: invoke end game and do some shiny stuff
		protected override void OnDeath()
		{
			_enemyTargetRegistry.Unregister(transform);
			Destroy(gameObject);
		}
	}
}