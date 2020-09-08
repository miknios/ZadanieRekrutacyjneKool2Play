using UnityEngine;
using Zenject;

namespace Enemy.TargetFollowing
{
	public class EnemyTarget : MonoBehaviour
	{
		[Inject]
		public void Initialize(IEnemyTargetRegistry enemyTargetRegistry)
		{
			enemyTargetRegistry.Register(transform);
		}
	}
}