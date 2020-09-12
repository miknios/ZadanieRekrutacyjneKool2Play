using System;
using Enemy.TargetFollowing;
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
		_enemyPrefabPool.Spawn(position, Quaternion.identity);
	}

	private Vector3 GetRandomPositionNearEnemyTarget()
	{
		_enemyTargetRegistry.TryGetRandomTarget(out var randomTargetPosition);
		Vector2 randomPointInCircle = Random.insideUnitCircle * maxDistanceFromTarget;

		randomTargetPosition.x += randomPointInCircle.x;
		randomTargetPosition.z += randomPointInCircle.y;
		return randomTargetPosition;
	}
}