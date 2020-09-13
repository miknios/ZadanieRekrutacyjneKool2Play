using UnityEngine;

[CreateAssetMenu(menuName = "Create BulletConfig", fileName = "BulletConfig")]
public class BulletConfig : ScriptableObject
{
	public int damage;
	public float damageDealFrequency;
	public float range;
	public float speed;
	public bool penetrable;
	public float scale;
	public BulletType bulletType;
	public Material material;
	public int poolPrewarm;
	public int poolIncreaseStep;
}

public enum BulletType
{
	Projectile,
	Hitscan,
}