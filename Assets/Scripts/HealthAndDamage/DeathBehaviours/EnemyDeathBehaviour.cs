using DG.Tweening;
using ObjectPool;
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
		private Vector3 initialScale;
		
		[Inject]
		private void Initialize(ScoreCounter scoreCounter)
		{
			_scoreCounter = scoreCounter;
			_sourcePool = GetComponent<SourcePool>();
			initialScale = transform.localScale;
		}
		
		protected override void OnDeath()
		{
			transform.DOScale(0f, scaleDownTime)
				.OnComplete(() =>
				{
					_sourcePool.PrefabPool.Despawn(gameObject);
					transform.localScale = initialScale;
				});
				
			_scoreCounter.Increment();
		}
	}
}