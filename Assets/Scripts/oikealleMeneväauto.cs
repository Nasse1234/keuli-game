﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oikealleMeneväauto : MonoBehaviour {

    //Spawn this object
    public GameObject spawnObject;

    public float maxTime = 50;
    public float minTime = 10;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start()
    {
      
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = 0; //Change this line
        Instantiate(spawnObject, transform.position, spawnObject.transform.rotation);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

}

