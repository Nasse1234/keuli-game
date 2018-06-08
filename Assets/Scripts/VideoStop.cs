using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;
public class VideoStop : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("mopo").GetComponent<mopedPhysics>().gameOver)
        {
            videoPlayer.Pause();
            
        }

    }
}
