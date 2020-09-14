using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyTargetFollower : MonoBehaviour
	{
		[SerializeField] private float speed = 10f;
		[SerializeField] private Rigidbody _rigidbody = null;

		private IEnemyTargetRegistry _enemyTargetRegistry;
		private Vector3 _normalizedMoveVector;

		[Inject]
		public void ConstructWithInjection(IEnemyTargetRegistry enemyTargetRegistry)
		{
			_enemyTargetRegistry = enemyTargetRegistry;
		}

		private void FixedUpdate()
		{
			if (_enemyTargetRegistry.TryGetClosestTargetTo(transform.position, out var targetPosition))
				SetMoveVectorFromTargetPosition(targetPosition);
			else
				SetRandomMoveVector();
			
			ApplyMoveVector();
		}

		private void SetRandomMoveVector()
		{
			_normalizedMoveVector = GetRandomDirection().normalized;
		}

		private void SetMoveVectorFromTargetPosition(Vector3 targetPosition)
		{
			Vector3 direction = targetPosition - transform.position;
			if (direction.magnitude <= 0.3f)
				SetRandomMoveVector();
			else
				_normalizedMoveVector = direction.normalized;
		}

		private Vector3 GetRandomDirection()
		{
			Vector3 randomDirection = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.forward;
			Vector3 smoothed = Vector3.Lerp(_normalizedMoveVector, randomDirection.normalized, 0.1f);
			return smoothed;
		}

		private void ApplyMoveVector()
		{
			Vector3 scaledMoveVector = _normalizedMoveVector * (speed * Time.deltaTime);
			_rigidbody.MoveRotation(Quaternion.LookRotation(scaledMoveVector));
			_rigidbody.MovePosition(transform.position + scaledMoveVector);
		}
	}
}