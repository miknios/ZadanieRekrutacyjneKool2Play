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
	private PrefabPool enemyPrefabPool;
	
	[Inject]
	private void Initialize(IEnemyTargetRegistry enemyTargetRegistry)
	{
		_enemyTargetRegistry = enemyTargetRegistry;
		Observable.Interval(TimeSpan.FromSeconds(spawnFrequency))
			.Subscribe(_ => SpawnEnemy());
	}

	private void Start()
	{
		enemyPrefabPool = PrefabPoolUtils.PoolForPrefab(enemyPrefab);
	}

	private void SpawnEnemy()
	{
		Vector3 position = GetRandomPositionNearEnemyTarget();
		enemyPrefabPool.Spawn(position, Quaternion.identity);
		
		Debug.Log("Spawning new enemy");
	}

	private Vector3 GetRandomPositionNearEnemyTarget()
	{
		var randomTargetPos = _enemyTargetRegistry.GetRandomTarget();
		Vector2 randomPointInCircle = Random.insideUnitCircle * maxDistanceFromTarget;

		randomTargetPos.x += randomPointInCircle.x;
		randomTargetPos.z += randomPointInCircle.y;
		return randomTargetPos;
	}
}