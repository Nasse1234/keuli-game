using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Sprites;
using UnityEngine.Advertisements;

public class mopedPhysics : MonoBehaviour {

    public Sprite senda, dt, fantic, monkey, pv;

    private float ScreenWidth;
    private float ScreenHeight;
    float verSpeed;
    int power;
    int putoamisVauhti;
    public bool gameOver = false;
    public bool peliAlkanut = false;
    int frames;
    public Text textscore;
    public Text HighScoreText;
    public Text GameOverScoreText;
    public int score = 0;
    public int HighScore;
    public int coinsplus;
    public GameObject objGameOver;
    public Text CoinsPlusText;
    public Rigidbody2D rb2D;
    public int Coins;

    private SpriteRenderer spriteR;

    void Start()
    {
        
        score = 0;

        verSpeed = 1.5f;

        putoamisVauhti = 150;
        power = 115;
        
        Coins = PlayerPrefs.GetInt("Coins");
        HighScore = PlayerPrefs.GetInt("HighScore");

        StartCoroutine(aloitusAika());

        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;

        int moped = PlayerPrefs.GetInt("moped");
        if (moped == 1)
        {
            spriteR.sprite = senda;
            print("derbi");
        }
        else if (moped == 2)
        {
            spriteR.sprite = dt;
            print("dt");
        }
        else if (moped == 3)
        {
            spriteR.sprite = fantic;
            print("fantic");
        }
        else if(moped == 4)
        {
            spriteR.sprite = monkey;
        }
        else if(moped == 5)
        {
            spriteR.sprite = pv;
        }

        spriteR = gameObject.GetComponent<SpriteRenderer>();

        objGameOver.SetActive(false);

        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        frames++;
        print(rb2D.rotation);

        if (gameOver == true)
        {
            GameOver();
        }

        textscore.text = "Score: " + score;

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
        if(rb2D.rotation < 30)
        {
            power = 75;
        }
        else
        {
            power = 115;
        }

        if(peliAlkanut == true && gameOver == false && frames % 10 == 0)
        {
               
                score++;
            
            
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
        if (HighScore < score)
        {
            HighScore = score;
        }
        coinsplus = score / 10;

        rb2D.velocity = new Vector2(0, 0);

        
        HighScoreText.text = "High Score: " + HighScore;
        CoinsPlusText.text = "+" + coinsplus + " Coins";
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
    public void restart()
    {
        if(score > 100)
        {
            if (Advertisement.IsReady("gameoverad"))
            {
                Advertisement.Show("gameoverad");
            }
        }
       
        SceneManager.LoadScene(2);
    }

    IEnumerator aloitusAika()
    {
        yield return new WaitForSeconds(5);
        peliAlkanut = true;
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.SetInt("Coins", coinsplus + Coins);
        PlayerPrefs.Save();
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
