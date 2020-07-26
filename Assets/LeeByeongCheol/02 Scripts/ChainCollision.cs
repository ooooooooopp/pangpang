using UnityEngine;

public class ChainCollision : MonoBehaviour
{

	float power = 100.0f;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Chain.IsFired = false;
		if (col.tag == TagName.BALL)
		{
			var dmg = col.GetComponent<IDamagable>();
			if ( dmg != null ) {
				dmg.TakeDamage( new DamagableData() {
					attacker = gameObject,
					damage = power,
				} );
			}
		}

	}

}


