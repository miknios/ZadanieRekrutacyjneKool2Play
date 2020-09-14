using DG.Tweening;
using ObjectPool;
using UniRx;
using UnityEngine;

namespace HealthAndDamage
{
	[RequireComponent(typeof(HealthComponent))]
	public class DamageDealtAnimator : MonoBehaviour, ISpawnInitializable
	{
		private HealthComponent _healthComponent;
		private int _previousValue;
		private Vector3 _initialScale;

		private void Awake()
		{
			_healthComponent = GetComponent<HealthComponent>();
			_initialScale = transform.localScale;
		}

		private void Start()
		{
			_healthComponent.Current
				.Skip(1)
				.Subscribe(value =>
				{
					if(value < _previousValue)
						Animate();
				
					_previousValue = value;
				});
		}

		private void Animate()
		{
			transform.DOShakeScale(0.1f, 0.6f, 5, 40f)
				.OnStart(() => transform.localScale = _initialScale)
				.OnComplete(() => transform.localScale = _initialScale);
		}

		public void InitializeOnSpawn()
		{
			_previousValue = int.MaxValue;
		}
	}
}