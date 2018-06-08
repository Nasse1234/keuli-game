using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VastaantulevaAuto : MonoBehaviour {

        //Spawn this object
        public GameObject spawnObject;

        public float maxTime = 20;
        public float minTime = 10;

        //current time
        public float timeL;
        

        //The time to spawn the object
        private float spawnTime;

        void Start()
        {
            SetRandomTime();
            timeL = minTime;
        }

        void FixedUpdate()
        {

            //Counts up
            timeL += Time.deltaTime;

            //Check if its the right time to spawn the object
            if (timeL >= spawnTime)
            {
                SpawnObject();
                SetRandomTime();
            }

        }


        //Spawns the object and resets the time
        void SpawnObject()
        {
            timeL = 0; //Change this line
            Instantiate(spawnObject, transform.position, spawnObject.transform.rotation);
        }

        //Sets the random time between minTime and maxTime
        void SetRandomTime()
        {
            spawnTime = Random.Range(minTime, maxTime);
        }

}