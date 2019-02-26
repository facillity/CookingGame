using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{

    float timer = -3;
    float timer2 = 0;
    public Text text;
    public Text text2;
    public Text text3;
    private string[] letters = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

    public GameObject salmonSprite;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;

    private string chosenLetter;
    private int points = 0;

    private bool doOnce = false;

    private bool endState = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && !doOnce){
            doOnce = true;
            spawnLetter();
        }
        
        if (timer < 20){
            timer += Time.deltaTime;
        } else {
            endState = true;
            text.color = Color.red;
        }
        
        text.text = "Timer: " + timer.ToString("0:00");

        if (Input.GetKeyDown("a")){
            pressed("a");
        } else if (Input.GetKeyDown("b")){
            pressed("b");
        } else if (Input.GetKeyDown("c")){
            pressed("c");
        } else if (Input.GetKeyDown("d")){
            pressed("d");
        } else if (Input.GetKeyDown("e")){
            pressed("e");
        } else if (Input.GetKeyDown("f")){
            pressed("f");
        } else if (Input.GetKeyDown("g")){
            pressed("g");
        } else if (Input.GetKeyDown("h")){
            pressed("h");
        } else if (Input.GetKeyDown("i")){
            pressed("i");
        } else if (Input.GetKeyDown("j")){
            pressed("j");
        } else if (Input.GetKeyDown("k")){
            pressed("k");
        } else if (Input.GetKeyDown("l")){
            pressed("l");
        } else if (Input.GetKeyDown("m")){
            pressed("m");
        } else if (Input.GetKeyDown("n")){
            pressed("n");
        } else if (Input.GetKeyDown("o")){
            pressed("o");
        } else if (Input.GetKeyDown("p")){
            pressed("p");
        } else if (Input.GetKeyDown("q")){
            pressed("q");
        } else if (Input.GetKeyDown("r")){
            pressed("r");
        } else if (Input.GetKeyDown("s")){
            pressed("s");
        } else if (Input.GetKeyDown("t")){
            pressed("t");
        } else if (Input.GetKeyDown("u")){
            pressed("u");
        } else if (Input.GetKeyDown("v")){
            pressed("v");
        } else if (Input.GetKeyDown("w")){
            pressed("w");
        } else if (Input.GetKeyDown("x")){
            pressed("x");
        } else if (Input.GetKeyDown("y")){
            pressed("y");
        } else if (Input.GetKeyDown("z")){
            pressed("z");
        }

        if (endState){
            timer2 += Time.deltaTime;

            if (timer2 > 7.5f){
                // get progress to add 1
                GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
                SceneManager.LoadScene("SalmonNigiriRecipe");
            }
        }
    }

    void spawnLetter(){
        int chosen = Random.Range(0, 26);
        text2.text = "PRESS: " + letters[chosen];
        chosenLetter = letters[chosen];
    }

    void pressed(string s){
        if (doOnce && !endState){
            if (chosenLetter == s){
                points++;
                spawnLetter();
                progressSprite(true);
            } else {
                if (points != 0)
                    points--;
                spawnLetter();
            }
            updateText();
        }
    }

    void progressSprite(bool t){
        int currStage = salmonSprite.GetComponent<SalmonScript>().stage;
        if (t){
            
            if (currStage == 0){
                salmonSprite.GetComponent<SpriteRenderer>().sprite = s2;
            } else if (currStage == 1){
                salmonSprite.GetComponent<SpriteRenderer>().sprite = s3;
            } else if (currStage == 2){
                salmonSprite.GetComponent<SpriteRenderer>().sprite = s4;
            } else if (currStage == 3){
                salmonSprite.GetComponent<SpriteRenderer>().sprite = s5;
            } else if (currStage == 4){
                salmonSprite.GetComponent<SpriteRenderer>().sprite = s6;
            } else if (currStage == 5){
                salmonSprite.GetComponent<SpriteRenderer>().sprite = s1;
            } else {
                Debug.Log("Wrong?");
            }
            
            if (currStage + 1 == 6){
                salmonSprite.GetComponent<SalmonScript>().stage = 0;
            } else {
                salmonSprite.GetComponent<SalmonScript>().stage ++;
            }
        } else {

        }
    }

    void updateText(){
        text3.text = "Salmon Pieces: " + points.ToString();
    }

}
