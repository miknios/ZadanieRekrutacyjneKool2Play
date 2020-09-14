using DG.Tweening;
using HealthAndDamage;
using ObjectPool;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class DamageDealtAnimator : MonoBehaviour, ISpawnInitializable
{
	private HealthComponent _healthComponent;
	private int _previousValue;

	private void Awake()
	{
		_healthComponent = GetComponent<HealthComponent>();
	}

	private void Start()
	{
		_healthComponent.Current
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
			.OnStart(() => transform.localScale = Vector3.one);
	}

	public void InitializeOnSpawn()
	{
		_previousValue = int.MaxValue;
	}
}