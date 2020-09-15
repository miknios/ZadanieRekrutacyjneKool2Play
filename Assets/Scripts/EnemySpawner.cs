using System;
using DG.Tweening;
using Enemy;
using ObjectPool;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab = null;
	[SerializeField] private float spawnFrequency = 1f;
	[SerializeField] private float maxDistanceFromTarget = 15f;
	[SerializeField] private float scaleUpTime = 0.3f;
	
	private IEnemyTargetRegistry _enemyTargetRegistry;
	private PrefabPool _enemyPrefabPool;
	
	[Inject]
	private void Initialize(IEnemyTargetRegistry enemyTargetRegistry)
	{
		_enemyTargetRegistry = enemyTargetRegistry;
		Observable.Interval(TimeSpan.FromSeconds(spawnFrequency))
			.Subscribe(_ => SpawnEnemy());
	}

	private void Start()
	{
		_enemyPrefabPool = PrefabPoolUtils.PoolForPrefab(enemyPrefab);
	}

	private void SpawnEnemy()
	{
		Vector3 position = GetRandomPositionNearEnemyTarget();
		var enemy = _enemyPrefabPool.Spawn(position, Quaternion.identity);
		enemy.transform
			.DOScale(enemy.transform.localScale, scaleUpTime)
			.From(0);
	}

	private Vector3 GetRandomPositionNearEnemyTarget()
	{
		_enemyTargetRegistry.TryGetRandomTarget(out var randomTargetPosition);
		Vector2 randomPointInCircle = Random.insideUnitCircle * maxDistanceFromTarget;

		randomTargetPosition.x += randomPointInCircle.x;
		randomTargetPosition.y = enemyPrefab.transform.position.y;
		randomTargetPosition.z += randomPointInCircle.y;
		return randomTargetPosition;
	}
}