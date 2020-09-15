using DG.Tweening;
using ObjectPool;
using UniRx;
using UnityEngine;

namespace HealthAndDamage
{
	[RequireComponent(typeof(HealthComponent))]
	public class DamageDealtAnimator : MonoBehaviour, ISpawnInitializable
	{
		private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
		
		[SerializeField] private Renderer _renderer = null;
		[SerializeField] private float duration = 0.1f;
		[SerializeField] private Color flashColor = Color.red;
		[SerializeField, ColorUsage(false, true)] private Color flashEmmisionColor = Color.red;
		
		private HealthComponent _healthComponent;
		private int _previousValue;
		private Vector3 _initialScale;
		private Color _initialColor;
		private Color _initialEmission;

		private void Awake()
		{
			_healthComponent = GetComponent<HealthComponent>();
			_initialScale = transform.localScale;
			_initialColor = _renderer.material.color;
			_initialEmission = _renderer.material.GetColor(EmissionColor);
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
			_renderer.material.DOColor(flashColor, duration)
				.From(_initialColor)
				.SetLoops(2, LoopType.Yoyo);
			_renderer.material.DOColor(flashEmmisionColor * 4, EmissionColor, duration)
				.From(_initialEmission)
				.SetLoops(2, LoopType.Yoyo);
		}

		public void InitializeOnSpawn()
		{
			_previousValue = int.MaxValue;
		}
	}
}