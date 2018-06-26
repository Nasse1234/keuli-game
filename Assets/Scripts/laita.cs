using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laita : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "mopo")
        {
            GameObject.Find("mopo").GetComponent<mopedPhysics>().gameOver = true;
        }
    }
}
