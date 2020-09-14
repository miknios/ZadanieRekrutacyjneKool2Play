using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
	public interface IEnemyTargetRegistry
	{
		bool TryGetClosestTargetTo(Vector3 position, out Vector3 targetPosition);
		bool TryGetRandomTarget(out Vector3 targetPosition);
		void Register(Transform transform);
		void Unregister(Transform transform);
	}
	
	public class EnemyTargetRegistry : IEnemyTargetRegistry
	{
		private readonly IList<Transform> _registeredTargets = new List<Transform>();

		public bool TryGetClosestTargetTo(Vector3 position, out Vector3 targetPosition)
		{
			targetPosition = Vector3.zero;
			if (_registeredTargets.Count == 0)
				return false;
			
			Vector3 closestTargetPos = _registeredTargets[0].position;
			float minDistance = Vector3.Distance(closestTargetPos, position);
			for (int i = 0; i < _registeredTargets.Count; i++)
			{
				var target = _registeredTargets[i];
				float distance = Vector3.Distance(target.position, position);
				if (distance < minDistance)
				{
					minDistance = distance;
					closestTargetPos = target.position;
				}
			}

			targetPosition = closestTargetPos;
			return true;
		}

		public bool TryGetRandomTarget(out Vector3 targetPosition)
		{
			targetPosition = Vector3.zero;
			
			int targetCount = _registeredTargets.Count;
			if(targetCount == 0)
				return false;
			
			int randomTargetIndex = Random.Range(0, targetCount - 1);
			targetPosition = _registeredTargets[randomTargetIndex].position;
			
			return true;
		}

		public void Register(Transform transform)
		{
			_registeredTargets.Add(transform);
		}

		public void Unregister(Transform transform)
		{
			_registeredTargets.Remove(transform);
		}
	}
}