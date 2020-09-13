using ObjectPool;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
	private PrefabPool _prefabPool;
	
	[SerializeField] protected int Damage;
	[SerializeField] protected float Range;
	[SerializeField] protected float Speed;
	[SerializeField] protected float DamageDealFrequency;
	[SerializeField] protected bool Penetrable;

	public virtual void Initialize(BulletConfig bulletConfig)
	{
		Damage = bulletConfig.damage;
		Range = bulletConfig.range;
		Penetrable = bulletConfig.penetrable;
	}

	public void Fire(Vector3 direction, PrefabPool prefabPool)
	{
		_prefabPool = prefabPool;
		DoFire(direction);
	}
	
	protected abstract void DoFire(Vector3 direction);

	protected void Destroy()
	{
		Debug.Log("Bullet.Destroy()");
		_prefabPool.Despawn(gameObject);
	}
}