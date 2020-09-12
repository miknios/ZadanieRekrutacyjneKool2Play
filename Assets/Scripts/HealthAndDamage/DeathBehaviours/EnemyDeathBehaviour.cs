using Score;
using Zenject;

namespace HealthAndDamage.DeathBehaviours
{
	public class EnemyDeathBehaviour : DeathBehaviour
	{
		private ScoreCounter _scoreCounter;
		
		[Inject]
		private void Initialize(ScoreCounter scoreCounter)
		{
			_scoreCounter = scoreCounter;
		}
		
		// TODO: do some shiny stuff
		protected override void OnDeath()
		{
			Destroy(gameObject);
			_scoreCounter.Increment();
		}
	}
}