using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuQuit : MonoBehaviour {

    public void Quit()
    {
        Application.Quit();
    }
    public void clear()
    {
        PlayerPrefs.DeleteAll();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
