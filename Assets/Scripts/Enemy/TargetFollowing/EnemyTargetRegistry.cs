using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.TargetFollowing
{
	public interface IEnemyTargetRegistry
	{
		Vector3 GetClosestTargetTo(Vector3 position);
		Vector3 GetRandomTarget();
		void Register(Transform transform);
		void Unregister(Transform transform);
	}
	
	public class EnemyTargetRegistry : IEnemyTargetRegistry
	{
		private readonly IList<Transform> _registeredTargets = new List<Transform>();

		public Vector3 GetClosestTargetTo(Vector3 position)
		{
			if (_registeredTargets.Count == 0)
				return position;
			
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

			return closestTargetPos;
		}

		public Vector3 GetRandomTarget()
		{
			int targetCount = _registeredTargets.Count;
			int randomTargetIndex = Random.Range(0, targetCount - 1);
			
			return _registeredTargets[randomTargetIndex].position;
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