using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCreamStirLogic : MonoBehaviour
{
    int fuckUpTimeStart;
    int lenience;
    int lives;
    public GameObject ProgBar;
    public GameObject GameOverUI;
    public Text livesCounter;

    private void Awake()
    {
        lenience = 2;
        lives = 3;
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
        if (transform.localScale.x <= 0)
        {
            LoseLifeWithCooldown();
        }
        if (ProgBar.transform.localScale.x >= 95)
        {
            LoseLifeWithCooldown();
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
