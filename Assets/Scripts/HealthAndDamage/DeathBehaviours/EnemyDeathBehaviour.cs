using DG.Tweening;
using Score;
using UnityEngine;
using Zenject;

namespace HealthAndDamage.DeathBehaviours
{
	public class EnemyDeathBehaviour : DeathBehaviour
	{
		[SerializeField] private float scaleDownTime = 0.2f;
		
		private ScoreCounter _scoreCounter;
		private SourcePool _sourcePool;
		
		[Inject]
		private void Initialize(ScoreCounter scoreCounter)
		{
			_scoreCounter = scoreCounter;
			_sourcePool = GetComponent<SourcePool>();
		}
		
		protected override void OnDeath()
		{
			transform.DOScale(0f, scaleDownTime)
				.OnComplete(() => _sourcePool.PrefabPool.Despawn(gameObject));
				
			_scoreCounter.Increment();
		}
	}
}