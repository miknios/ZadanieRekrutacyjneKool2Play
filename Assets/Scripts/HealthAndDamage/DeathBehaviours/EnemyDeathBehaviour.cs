namespace HealthAndDamage.DeathBehaviours
{
	public class EnemyDeathBehaviour : DeathBehaviour
	{
		// TODO: do some shiny stuff
		protected override void OnDeath()
		{
			Destroy(gameObject);
		}
	}
}