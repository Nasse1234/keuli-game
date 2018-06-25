using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class autoPhysics : MonoBehaviour {
    public Rigidbody2D rb2D;

    private SpriteRenderer spriteR;

    public Sprite auto1, auto2, auto3, auto4, auto5;
    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        int vari = Random.Range(1, 5);

        spriteR = gameObject.GetComponent<SpriteRenderer>();
        if (vari == 1)
        {
            spriteR.sprite = auto1;
        }
        else if(vari == 2)
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
    void Update()
    {
        if (GameObject.Find("mopo").GetComponent<mopedPhysics>().gameOver)
        {
            rb2D.velocity = new Vector2(0, 0);
        }
        else
        {
            rb2D.velocity = new Vector2(-3f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "AutonTuhoaja")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.name == "mopo")
        {
            GameObject.Find("mopo").GetComponent<mopedPhysics>().gameOver = true;
        }
    }




}
