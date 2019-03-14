using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EggCrackLogic : MonoBehaviour
{
    public GameObject eggObject;
    public Text remainingText;
    public GameObject goodText, perfectText, terribleText, winText;
    public Sprite eggNormal, eggCrack, eggOpen, eggBroken;
    public GameObject SoundEffects;

    private int eggsRemaining;
    private bool keyDown;
    private float animationTimer = 0f;
    private int speedScale = 1;
    private int crackAmount = 0;
    private bool winState;
    private bool resetEgg;
    private bool animationPlaying;

    // Start is called before the first frame update
    void Start()
    {
        eggsRemaining = 10;
        setRemainingText();
        keyDown = false;
        winState = false;
        resetEgg = false;
        animationPlaying = false;

        disableUIElements();
    }

    // Update is called once per frame
    void Update()
    {
        if (ProgressScript.cheats && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C)){
            Debug.Log("SKIPPED.");
            winState = true;
        }
        if (animationTimer >= 0)
        {
            animationTimer -= Time.deltaTime;
        }
        if (animationTimer <= 0 && animationPlaying)
        {
            animationPlaying = false;
            disableUIElements();
            if (winState)
            {
                GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
                SceneManager.LoadScene("BreakfastRecipe");
            }
            else
            {
                if (resetEgg)
                {
                    resetEgg = false;
                    crackAmount = 0;
                    eggObject.GetComponent<SpriteRenderer>().sprite = eggNormal;
                }
                this.GetComponent<Transform>().position = new Vector3(-4.947f, -3.96f, 0);
                this.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            }
        }



        if (Input.GetKey("space") && animationTimer <= 0f)
        {
            //12.8 320 is fast (x4)
            keyDown = true;
            this.GetComponent<Transform>().position += new Vector3(3.2f * Time.deltaTime * speedScale, 0, 0);
            this.GetComponent<Transform>().localScale += new Vector3(80f * Time.deltaTime * speedScale, 0, 0);
        }
        else if (Input.GetKeyUp("space") && keyDown && animationTimer <= 0f)
        {
            keyDown = false;
            determineResult();
        }
        if (this.GetComponent<Transform>().localScale.x >= 123.8 && animationTimer <= 0f)
        {
            keyDown = false;
            determineResult();
        }
    }


    private void disableUIElements()
    {
        perfectText.SetActive(false);
        goodText.SetActive(false);
        terribleText.SetActive(false);
        winText.SetActive(false);
    }



    private void determineResult()
    {
        float scaleSize = this.GetComponent<Transform>().localScale.x;
        animationPlaying = true;

        animationTimer = 1.0f;
        
        if (scaleSize <= 81.2)
        {
            //red
            eggObject.GetComponent<SpriteRenderer>().sprite = eggBroken;
            terribleText.SetActive(true);
            resetEgg = true;
            SoundEffects.GetComponent<EggMinigameSoundScript>().PlaySoundEffect("error");
        }
        else if (scaleSize <= 89.5)
        {
            //yellow
            if (crackAmount == 1)
            {
                eggObject.GetComponent<SpriteRenderer>().sprite = eggOpen;
                crackAmount = 0;
                --eggsRemaining;
                setRemainingText();
                resetEgg = true;
                SoundEffects.GetComponent<EggMinigameSoundScript>().PlaySoundEffect("open");
            }
            else
            {
                eggObject.GetComponent<SpriteRenderer>().sprite = eggCrack;
                ++crackAmount;
                SoundEffects.GetComponent<EggMinigameSoundScript>().PlaySoundEffect("crack");
            }
            if (eggsRemaining == 0)
            {
                winText.SetActive(true);
                winState = true;
                animationTimer = 4f;
            }
            else
            {
                goodText.SetActive(true);
            }
        }
        else if (scaleSize <= 93.4)
        {
            //green
            eggObject.GetComponent<SpriteRenderer>().sprite = eggOpen;
            --eggsRemaining;
            setRemainingText();
            if (eggsRemaining == 0)
            {
                winText.SetActive(true);
                winState = true;
                animationTimer = 4f;
            }
            else
            {
                perfectText.SetActive(true);
                resetEgg = true;
            }
            SoundEffects.GetComponent<EggMinigameSoundScript>().PlaySoundEffect("open");
        }
        else if (scaleSize <= 100.8)
        {
            //yellow
            if (crackAmount == 1)
            {
                eggObject.GetComponent<SpriteRenderer>().sprite = eggOpen;
                crackAmount = 0;
                --eggsRemaining;
                setRemainingText();
                resetEgg = true;
                SoundEffects.GetComponent<EggMinigameSoundScript>().PlaySoundEffect("open");
            }
            else
            {
                eggObject.GetComponent<SpriteRenderer>().sprite = eggCrack;
                ++crackAmount;
                SoundEffects.GetComponent<EggMinigameSoundScript>().PlaySoundEffect("crack");
            }
            if (eggsRemaining == 0)
            {
                winText.SetActive(true);
                winState = true;
                animationTimer = 4f;
            }
            else
            {
                goodText.SetActive(true);
            }
        }
        else
        {
            //red
            eggObject.GetComponent<SpriteRenderer>().sprite = eggBroken;
            terribleText.SetActive(true);
            resetEgg = true;
            SoundEffects.GetComponent<EggMinigameSoundScript>().PlaySoundEffect("error");
        }

        updateGameSpeed();
    }


    private void updateGameSpeed()
    {
        if (eggsRemaining > 7)
        {
            speedScale = 1;
        }
        else if (eggsRemaining > 3)
        {
            speedScale = 2;
        }
        else
        {
            speedScale = 4;
        }
    }


    private void setRemainingText()
    {
        remainingText.text = "remaining eggs: " + eggsRemaining.ToString();
    }
}
