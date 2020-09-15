using DG.Tweening;
using ObjectPool;
using UniRx;
using UnityEngine;

namespace HealthAndDamage
{
	[RequireComponent(typeof(HealthComponent))]
	public class DamageDealtAnimator : MonoBehaviour, ISpawnInitializable
	{
		[SerializeField] private Renderer _renderer;
		[SerializeField] private float duration;
		
		private HealthComponent _healthComponent;
		private int _previousValue;
		private Vector3 _initialScale;
		private Color _initialColor;

		private void Awake()
		{
			_healthComponent = GetComponent<HealthComponent>();
			_initialScale = transform.localScale;
			_initialColor = _renderer.material.color;
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
			Bounce();
			Flash();
		}

		private void Bounce()
		{
			transform.DOShakeScale(duration, 0.6f, 5, 40f)
				.OnStart(() => transform.localScale = _initialScale)
				.OnComplete(() => transform.localScale = _initialScale);
		}

		private void Flash()
		{
			duration = 0.1f;
			_renderer.material.DOColor(Color.yellow, duration)
				.From(_initialColor)
				.SetLoops(2, LoopType.Yoyo);
		}

		public void InitializeOnSpawn()
		{
			_previousValue = int.MaxValue;
		}
	}
}