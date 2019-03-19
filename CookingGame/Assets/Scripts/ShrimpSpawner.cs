using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShrimpSpawner : MonoBehaviour
{
    public Text Timer;
    public Text LivesLeft;
    public Text winText;
    public Text GameOverUI;
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
    int totalTime;
    List<GameObject> shrimps;
    bool isGameOver;
    int NumShrimpFinished;
    int NumShrimpBurnt;
    int lives;
    int timeLeft;

    private void Awake()
    {
        totalTime = 25;
        lives = 3;
        NumShrimpBurnt = 0;
        timeLeft = totalTime;
        isGameOver = false;

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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ProgressScript.cheats && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("SKIPPED");
            StartCoroutine(pauseAndWin());
        }
        if (checkIfFinished())
        {
            StartCoroutine(pauseAndWin());
        }
        if (lives <= 0 || timeLeft <= 0)
        {
            gameOver();
            totalTime += totalTime - timeLeft;
            StartCoroutine(pauseAndReset());
            //reset();
        }
        advanceTime();
    }

    public void loseLife()
    {
        lives--;
        LivesLeft.text = "Lives: " + lives.ToString();
    }

    private void advanceTime()
    {
        //Debug.Log(timeLeft);
        timeLeft = totalTime - (int)Time.timeSinceLevelLoad;
        Timer.text = "Time Left: " + timeLeft.ToString();
    }

    IEnumerator pauseAndReset()
    {
        
        Time.timeScale = 0;
        float stopTime = Time.realtimeSinceStartup + 3;
        while(Time.realtimeSinceStartup < stopTime)
        {
            //Debug.Log(Time.time);
            lives = 3;
            GameOverUI.gameObject.SetActive(true);
            yield return 0;
        }
        
        Time.timeScale = 1;
        //Debug.Log("end pause");
        reset();
        
        GameOverUI.gameObject.SetActive(false);
    }

    IEnumerator pauseAndWin()
    {
        Time.timeScale = 0;
        float stopTime = Time.realtimeSinceStartup + 3;
        while (Time.realtimeSinceStartup < stopTime)
        {
            //Debug.Log(Time.time);
            winText.gameObject.SetActive(true);
            yield return 0;
        }
        Time.timeScale = 1;
        GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
        SceneManager.LoadScene("ShrimpRecipe");
    }
    

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


    private void reset()
    {
        
        lives = 3;
        LivesLeft.text = "Lives: " + lives.ToString();
        isGameOver = false;
        foreach (GameObject s in shrimps)
        {
            s.GetComponent<Shrimp>().Reset();
        }
    }

    private void gameOver()
    {
        isGameOver = true;
        GameOverUI.gameObject.SetActive(true);
    }
}
