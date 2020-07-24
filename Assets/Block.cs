using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Sprite[] sprite;
    private int sprIndex;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sprIndex = sprite.Length;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.layer == 9)
		{
            BlockDamned();
        }
	}


	void BlockDamned()
    {
        if(sprIndex == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = sprite[sprIndex - 1];
            sprIndex--;
        }
    }

}
