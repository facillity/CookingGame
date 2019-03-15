using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCreamStirLogic : MonoBehaviour
{
    int fuckUpTimeStart;
    int lenience;
    int lives;
    float progress;
    public GameObject ProgBar;
    public Text GameOverUI;
    public Text WinText; 
    public Text livesCounter;
    public Text progText;

    private void Awake()
    {
        lenience = 3;
        lives = 3;
        progress = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0)
        {
            Time.timeScale = 0;
            GameOverUI.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        checkIfDone();
        if (ProgBar.transform.localScale.x <= 0)
        {
            LoseLifeWithCooldown();
        }
        else if (ProgBar.transform.localScale.x >= 95)
        {
            LoseLifeWithCooldown();
        }
        else
        {
            progress += 0.2F;
            int intProg = (int)progress;
            progText.text = "Progress: " + intProg.ToString() + "%";
        }
        
    }

    void checkIfDone()
    {
        if(progress >= 100)
        {
            Time.timeScale = 0;
            WinText.gameObject.SetActive(true);
        }
    }

    void LoseLifeWithCooldown()
    {
        if ((int)Time.time >= fuckUpTimeStart)
        {
            fuckUpTimeStart = (int)Time.time + lenience;
            --lives;
            livesCounter.text = "Lives: " + lives.ToString();
            Debug.Log(lives.ToString());
        }
    }
}
