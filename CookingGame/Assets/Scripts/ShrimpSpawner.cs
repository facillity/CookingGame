using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrimpSpawner : MonoBehaviour
{
    public Text Timer;
    public Text LivesLeft;
    public GameObject GameOverUI;
    public float SpawnMaxX;
    public float SpawnMaxY;
    public float SpawnMinX;
    public float SpawnMinY;
    public GameObject shrimp;
    public GameObject shrimp1;
    public GameObject shrimp2;
    public GameObject shrimp3;
    public GameObject shrimp4;
    public GameObject shrimp5;
    public GameObject shrimp6;
    public GameObject shrimp7;
    public int totalTime;
    List<GameObject> shrimps;
    int NumShrimpFinished;
    int NumShrimpBurnt;
    int lives;
    int timeLeft;

    private void Awake()
    {
        lives = 3;
        NumShrimpBurnt = 0;
        timeLeft = totalTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        shrimps = new List<GameObject>();
        shrimps.Add(shrimp);
        shrimps.Add(shrimp1);
        shrimps.Add(shrimp2);
        shrimps.Add(shrimp3);
        shrimps.Add(shrimp4);
        shrimps.Add(shrimp5);
        shrimps.Add(shrimp6);
        shrimps.Add(shrimp7);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = totalTime - (int)Time.time;
        if (checkIfFinished())
        {
            Time.timeScale = 0;
        }
        else if (lives<=0 || timeLeft<=0)
        {
            gameOver();
            totalTime += totalTime-timeLeft;
        }
        if (timeLeft >= 0)
        {
            Timer.text = "Time Left: " + timeLeft.ToString();
            int temp = (int)Time.time;
        }
    }

    public void loseLife()
    {
        lives--;
        LivesLeft.text = "Lives: " + lives.ToString();
    }


    /*void InstantiateShrimp()
    {
        float xPos = Random.Range(SpawnMinX, SpawnMaxX);
        float yPos = Random.Range(SpawnMinY, SpawnMaxY);
        Instantiate(shrimp, new Vector3(xPos, yPos, 0), Quaternion.identity);
        //shrimps[shrimps.Length] = shrimp;  
    }*/

    private bool checkIfFinished()
    {
        foreach(GameObject s in shrimps )
        {
            if(!s.GetComponent<Shrimp>().isFinished)
            {
                return false;
            }
        }
        return true;
    }

    

    private void gameOver()
    {
        foreach (GameObject s in shrimps)
        {
            s.GetComponent<Shrimp>().Reset();
        }
        GameOverUI.gameObject.SetActive(true);
        totalTime = 25;
        Timer.text = "Time Left: " + 25.ToString();
        lives = 3;
        LivesLeft.text = "Lives: " + lives.ToString();
        //Time.timeScale = 0;
    }
}
