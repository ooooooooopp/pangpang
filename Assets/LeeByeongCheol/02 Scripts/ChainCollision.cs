using UnityEngine;

public class ChainCollision : MonoBehaviour
{

	float power = 100.0f;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Chain.IsFired = false;
		if (col.tag == TagName.BALL)
		{
			col.GetComponent<IDamagable>().TakeDamage(new DamagableData()
			{
				attacker = gameObject,
				damage = power,
			});
		}

	}

}


