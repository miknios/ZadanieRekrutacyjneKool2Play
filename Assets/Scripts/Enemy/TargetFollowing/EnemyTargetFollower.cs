﻿using UnityEngine;
using Zenject;

namespace Enemy.TargetFollowing
{
	public class EnemyTargetFollower : MonoBehaviour
	{
		[SerializeField] private float speed = 10f;
		[SerializeField] private Rigidbody _rigidbody = null;
	
		private IEnemyTargetRegistry _enemyTargetRegistry;

		[Inject]
		public void Initialize(IEnemyTargetRegistry enemyTargetRegistry)
		{
			_enemyTargetRegistry = enemyTargetRegistry;
		}

		private void FixedUpdate()
		{
			Vector3 position = transform.position;
			Vector3 targetPosition = _enemyTargetRegistry.GetClosestTargetTo(position);
			Vector3 moveVectorNormalized = (targetPosition - position).normalized;
			Vector3 moveVectorScaled = moveVectorNormalized * (speed * Time.deltaTime);
		
			_rigidbody.MovePosition(position + moveVectorScaled);
		}
	}
}