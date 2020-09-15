using Cinemachine;
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
		[SerializeField] private CinemachineImpulseSource impulseSource;
		
		private ScoreCounter _scoreCounter;
		private SourcePool _sourcePool;
		private Vector3 initialScale;
		
		[Inject]
		private void Initialize(ScoreCounter scoreCounter)
		{
			_scoreCounter = scoreCounter;
			_sourcePool = GetComponent<SourcePool>();
			impulseSource = GetComponent<CinemachineImpulseSource>();
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
				
			impulseSource?.GenerateImpulse();
			_scoreCounter.Increment();
		}
	}
}