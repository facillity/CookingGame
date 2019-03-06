using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SausageCuttingLogic : MonoBehaviour
{

    float timer;
    private float endTimer;

    public Text text;
    public Text text2;
    public Text text3;
    public Text text4;

    public GameObject DashSprite;
    public GameObject KnifeSprite;
    public GameObject SoundEffects;

    private bool gameRunning;
    private bool endState;
    private int piecesLeft;

    // Start is called before the first frame update
    void Start()
    {
        resetGame();
    }

    void resetGame()
    {
        timer = 38f;
        endTimer = 0f;
        gameRunning = false;
        endState = false;
        piecesLeft = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 37 && timer > 36)
        {
            text4.text = "Ready";
        }
        if (timer <= 36 && timer > 35)
        {
            text4.text = "Set";
        }
        if (timer <= 35 && timer >= 34)
        {
            text4.text = "GO!";
        }
        if (timer < 34 && !gameRunning && !endState)
        {
            gameRunning = true;
            text4.gameObject.SetActive(false);
            DashSprite.SetActive(true);
            KnifeSprite.GetComponent<KnifeLogic>().canStartMoving = true;
            moveDashLine();
            updatePiecesText();
        }
        if (timer > 0 && !endState)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            endState = true;
            text.color = Color.red;
            //text2.text = "Oh no! Failed!";
        }

        text.text = "Timer: " + timer.ToString("0:00");


        if (Input.GetKeyDown("space"))
        {
            activateKnifeCut();
        }

        if (endState)
        {
            endTimer += Time.deltaTime;
            if (piecesLeft > 0)
            {
                text2.text = "Oh no! Failed!";
            }

            if (endTimer > 7.5f)
            {
                // get progress to add 1
                if (piecesLeft <= 0)
                {
                    //GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
                    Debug.Log("LOADING MAIN MENU");
                    SceneManager.LoadScene("_MainMenu");
                }
                else
                {
                    SceneManager.LoadScene("BreakfastRecipe");
                }
            }
        }
    }

    void activateKnifeCut()
    {
        if (!endState)
        {
            float knifeX = KnifeSprite.GetComponent<Transform>().position.x;
            float dashX = DashSprite.GetComponent<Transform>().position.x;

            if (Mathf.Abs(knifeX - dashX) <= 0.3f)
            {
                SoundEffects.GetComponent<SausageCuttingSoundScript>().PlaySoundEffect("success");
                --piecesLeft;
                updatePiecesText();
                moveDashLine();
            }
            else
            {
                SoundEffects.GetComponent<SausageCuttingSoundScript>().PlaySoundEffect("error");
            }

            if (piecesLeft == 0)
            {
                Debug.Log("IN HERE");
                DashSprite.SetActive(false);
                gameRunning = false;
                endState = true;
                KnifeSprite.GetComponent<KnifeLogic>().canStartMoving = false;
                KnifeSprite.GetComponent<KnifeLogic>().stopKnife();
                text2.text = "FINISHED! Good Job!";
            }
        }
    }

    void moveDashLine()
    {
        float randomX = Random.Range(-5.2f, 5.2f);
        DashSprite.GetComponent<Transform>().position = new Vector2(randomX, 0);
    }

    void updatePiecesText()
    {
        text3.text = "Pieces Left: " + piecesLeft;
    }
}
