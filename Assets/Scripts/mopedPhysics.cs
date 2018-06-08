using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mopedPhysics : MonoBehaviour {

    private float ScreenWidth;
    private float ScreenHeight;
    float verSpeed;
    int power;
    int putoamisVauhti;
    public bool gameOver = false;
    public bool peliAlkanut = false;

    public GameObject objGameOver;

    public Rigidbody2D rb2D;
    void Start()
    {
        StartCoroutine(aloitusAika());

        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;

        int moped = PlayerPrefs.GetInt("moped");
        if (moped == 1)
        {
            verSpeed = 3f;

            putoamisVauhti = 75;
            power = 50;
            print("derbi");
        }
        else if (moped == 2)
        {
            verSpeed = 2.5f;

            putoamisVauhti = 75;
            power = 75;
            print("dt");
        }
        else if (moped == 3)
        {
            verSpeed = 2f;

            putoamisVauhti = 75;
            power = 100;
            print("fantic");
        }


        objGameOver.SetActive(false);

        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        print(rb2D.rotation);

        if (gameOver == true)
        {
            GameOver();
        }
        


        if (rb2D.rotation > 0)
        {
            rb2D.MoveRotation(rb2D.rotation - putoamisVauhti * Time.fixedDeltaTime);
        }
        if (rb2D.rotation < 1 && peliAlkanut == true)
        {
            rb2D.velocity = new Vector2(0, 0);
            gameOver = true;
        }
        if (rb2D.rotation > 95)
        {
            rb2D.velocity = new Vector2(0, 0);
            gameOver = true;
        }

    

        if (gameOver == false)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x > Screen.width / 2)
                {

                    Gas();
                }
                else if (touch.position.x < Screen.width / 2 && touch.position.y > Screen.height / 2)
                {

                    Up();
                }
                else if (touch.position.x < Screen.width / 2 && touch.position.y < Screen.height / 2)
                {

                    Down();
                }
            }
        }
    }

    
    void GameOver()
    {
        objGameOver.SetActive(true);
    }

    void Up()
    {
        rb2D.velocity = new Vector2(0, verSpeed);
    }
    void Down()
    {
        rb2D.velocity = new Vector2(0, -verSpeed);
    }
    void Gas()
    {
        rb2D.MoveRotation(rb2D.rotation + power * Time.fixedDeltaTime);
    }

    IEnumerator aloitusAika()
    {
        yield return new WaitForSeconds(5);
        peliAlkanut = true;
    }
}
