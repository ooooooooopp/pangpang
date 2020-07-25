using UnityEngine;


public interface IDamagable
{
	bool TakeDamage( DamagableData data );
}

public struct DamagableData
{
	public GameObject attacker;
	public float damage;

	public static DamagableData New( float dmg, GameObject attacker )
	{
		return new DamagableData() {
			damage = dmg,
			attacker = attacker,
		};
	}
}

