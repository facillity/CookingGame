using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageSushiRice : MonoBehaviour
{
    public GameObject rice;
    private int count;
    private float space;
    private int round;
    public Text roundText, livesText, sushiLeftText;
    private float waitTime;
    private bool newRound;
    private bool wait;
    public static int lives;
    public static int sushiLeft;
    private bool won;
    // Start is called before the first frame update
    void Start()
    {
        sushiLeft = 3;
        lives = 3;
        wait = false;
        waitTime = 0;
        round = 1;
        count = 0;
        space = 4;
        newRound = true;
        won = false;
      //  Invoke("RandomlyGenerateRice", 1f);
        roundText.text = "Round 1!";
        Invoke("RandomlyGenerateRice", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + lives.ToString();
        sushiLeftText.text = "Pieces left: " + sushiLeft.ToString();
        if (won)
        {
            roundText.text = "Great job!";
        }
        else if (lives <= 0)
        {
            roundText.text = "You failed..";
        }
        else //if (lives > 0 && !won)
        {
            if (wait)
            {
                waitTime += Time.deltaTime;
                GameObject[] nigiri;
                nigiri = GameObject.FindGameObjectsWithTag("nigiri");
                for (int i = 0; i < nigiri.Length; i++)
                {
                    Destroy(nigiri[i]);
                }
            }
            else
            {
                if (sushiLeft == 0)
                {
                    if (round == 3)
                    {
                        won = true;
                    }
                    round++;
                    sushiLeft = 7;
                    Debug.Log("round " + round.ToString());
                    sushiLeft = 7;
                    newRound = true;
                }
                else if (round == 1 && newRound)
                {
                    //Invoke("RandomlyGenerateRice", 1f);
                    MoveSushiRice.speed = 2.5f;
                    wait = true;
                    space = 3.5f;
                    newRound = false;
                }
                else if (round == 2 && newRound)
                {
                    roundText.text = "Round 2!";
                    wait = true;
                    MoveSushiRice.speed = 4f;
                    space = 2;
                    newRound = false;
                }
                else if (round == 3 && newRound)
                {
                    roundText.text = "Round 3!";
                    wait = true;
                    MoveSushiRice.speed = 5.5f;
                    space = 2;
                    newRound = false;
                }
            }
            if (waitTime >= 4)
            {
                waitTime = 0;
                wait = false;
                roundText.text = "";
            }
        }
    }

    void RandomlyGenerateRice()
    {
        float randomInterval = space;//4f; // Random.Range(1f, 4f);  // can change this random time interval
        GenerateRice();
        Invoke("RandomlyGenerateRice", randomInterval);      
    }

    void GenerateRice()
    {
        Instantiate(rice, new Vector3(10f, 1.68f, 1), Quaternion.identity);
       // count++;
    }
}
