﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NopeaAutoOikealle : MonoBehaviour {

    public Rigidbody2D rb2D;
    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
            rb2D.velocity = new Vector2(-3, 0);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "AutonTuhoaja")
        {
            Destroy(gameObject);
        }
    }
}
