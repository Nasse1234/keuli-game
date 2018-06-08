using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mopedSelection : MonoBehaviour {
    public int moped;

    public void dööbi()
    {
        PlayerPrefs.SetInt("moped", 1);
    }
    public void monkey()
    {
        PlayerPrefs.SetInt("moped", 2);
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(moped);
	}
}
