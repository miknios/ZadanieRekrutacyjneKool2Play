using System;
using Cinemachine;
using DG.Tweening;
using ObjectPool;
using Score;
using UniRx;
using UnityEngine;
using Zenject;

namespace HealthAndDamage.DeathBehaviours
{
	public class EnemyDeathBehaviour : DeathBehaviour
	{
		[SerializeField] private float scaleDownTime = 0.2f;
		[SerializeField] private CinemachineImpulseSource impulseSource = null;
		[SerializeField] private ParticleSystem particlePrefab = null;

		private ScoreCounter _scoreCounter;
		private SourcePool _sourcePool;
		private Vector3 _initialScale;
		private PrefabPool _particlePrefabPool;
		private float _particleDuration;

		[Inject]
		private void Initialize(ScoreCounter scoreCounter)
		{
			_scoreCounter = scoreCounter;
			_sourcePool = GetComponent<SourcePool>();
			impulseSource = GetComponent<CinemachineImpulseSource>();
			_initialScale = transform.localScale;
			_particleDuration = particlePrefab.main.duration;
		}

		protected override void OnStart()
		{
			_particlePrefabPool = PrefabPoolUtils.PoolForPrefab(particlePrefab.gameObject);
		}

		protected override void OnDeath()
		{
			transform.DOScale(0f, scaleDownTime)
				.OnComplete(() =>
				{
					_sourcePool.PrefabPool.Despawn(gameObject);
					transform.localScale = _initialScale;
				});

			impulseSource?.GenerateImpulse();
			_scoreCounter.Increment();
			
			var particles = _particlePrefabPool.Spawn(transform.position, Quaternion.identity);
			Observable.Timer(TimeSpan.FromSeconds(_particleDuration))
				.Subscribe(_ => _particlePrefabPool.Despawn(particles));
		}
	}
}