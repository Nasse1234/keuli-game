using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class mopedSelection : MonoBehaviour {
    public int moped;
    public int Coins;
    public Text CoinsText;

    public int dtostettu;
    public int fanticostettu;
    public int monkeyostettu;
    public int pvostettu;

    public Button dtbutton;
    public Sprite dtimage;

    public Button fanticbutton;
    public Sprite fanticimage;

    public Button monkeybutton;
    public Sprite monkeyimage;

    public Button pvbutton;
    public Sprite pvimage;

    public void senda()
    {
        PlayerPrefs.SetInt("moped", 1);
        SceneManager.LoadScene(2);
    }

    public void showad()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
            PlayerPrefs.SetInt("Coins", Coins + 50);
        }
        
    }

    public void dt()
    {
        if(dtostettu == 1)
        {
            PlayerPrefs.SetInt("moped", 2);
            SceneManager.LoadScene(2);
            

        }
        else if(Coins >= 250)
        {
            PlayerPrefs.SetInt("Coins", Coins - 250);
            PlayerPrefs.SetInt("moped", 2);
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("dtostettu", 1);
            
        }
        
    }
    public void fantic()
    {
        if (fanticostettu == 1)
        {
            PlayerPrefs.SetInt("moped", 3);
            SceneManager.LoadScene(2);
        }
        else if (Coins >= 500)
        {
            PlayerPrefs.SetInt("Coins", Coins - 500);
            PlayerPrefs.SetInt("moped", 3);
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("fanticostettu", 1);

        }
    }
    public void monkey()
    {
        if (monkeyostettu == 1)
        {
            PlayerPrefs.SetInt("moped", 4);
            SceneManager.LoadScene(2);
        }
        else if (Coins >= 1000)
        {
            PlayerPrefs.SetInt("Coins", Coins - 1000);
            PlayerPrefs.SetInt("moped", 4);
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("monkeyostettu", 1);

        }
    }
    public void pv()
    {
        if (pvostettu == 1)
        {
            PlayerPrefs.SetInt("moped", 5);
            SceneManager.LoadScene(2);
        }
        else if (Coins >= 2000)
        {
            PlayerPrefs.SetInt("Coins", Coins - 2000);
            PlayerPrefs.SetInt("moped", 5);
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("pvostettu", 1);

        }
    }


    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        CoinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins");
        print(moped);

        dtostettu = PlayerPrefs.GetInt("dtostettu");
        fanticostettu = PlayerPrefs.GetInt("fanticostettu");
        monkeyostettu = PlayerPrefs.GetInt("monkeyostettu");
        pvostettu = PlayerPrefs.GetInt("pvostettu");

        if(dtostettu == 1)
        {
            dtbutton.GetComponent<Image>().sprite = dtimage;
        }
        if(fanticostettu == 1)
        {
            fanticbutton.GetComponent<Image>().sprite = fanticimage;
        }
        if(monkeyostettu == 1)
        {
            monkeybutton.GetComponent<Image>().sprite = monkeyimage;
        }
        if(pvostettu == 1)
        {
            pvbutton.GetComponent<Image>().sprite = pvimage;
        }

        Coins = PlayerPrefs.GetInt("Coins");
    }
    void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
