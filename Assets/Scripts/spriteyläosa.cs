using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteyläosa : MonoBehaviour {

    private SpriteRenderer spriteR;

    public Sprite auto1, auto2, auto3, auto4, auto5;
    // Use this for initialization
    void Start()
    {
        
        int vari = Random.Range(1, 5);

        spriteR = gameObject.GetComponent<SpriteRenderer>();
        if (vari == 1)
        {
            spriteR.sprite = auto1;
        }
        else if (vari == 2)
        {
            spriteR.sprite = auto2;
        }
        else if (vari == 3)
        {
            spriteR.sprite = auto3;
        }
        else if (vari == 4)
        {
            spriteR.sprite = auto4;
        }
        else if (vari == 5)
        {
            spriteR.sprite = auto5;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
