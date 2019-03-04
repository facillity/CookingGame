using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{

    float timer = 33;
    float timer2 = 0;
    public int chosen;
    public Text text;
    public Text text2;
    public Text text3;

    public Text text4;
    private string[] letters = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

    private string[] recipeNigiriString = {"first", "we", "must", "get", "the", "items", "on", "the", "list", "which", "include", "soy", "sauce", "vinegar", "salt",
                                        "sushi", "rice", "wasabi", "and", "salmon", "first", "we", "use", "the", "salt", "to", "cook", "the", "sushi", "rice", "then",
                                        "use", "the", "vinegar", "to", "coat", "the", "rice", "which", "we", "will", "then", "place", "our", "raw", "salmon", "on",
                                        "top", "of", "finally", "enjoy", "with", "wasabi"};
    public GameObject salmonSprite;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;

    private string chosenWord;
    private int wordsLeft;

    private bool doOnce = false;
    private string typedWord;
    private int on;

    private bool endState = false;
    // Start is called before the first frame update
    void Start()
    {
        //if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 1){
            resetNigiri();
        //}
    }

    void resetNigiri(){
        wordsLeft = recipeNigiriString.Length;
        timer = 43f;
        chosen = 0;
        timer2 = 0f;
        on = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 40 && !doOnce){
            doOnce = true;
            spawnWord();
        }
        if (timer <=42 && timer > 41){
            text4.text = "Ready";
        }
        if (timer <=41 && timer > 40){
            text4.text = "Set";
        }
        if (timer <=40 && timer >= 39){
            text4.text = "GO!";
        }
        if (timer <39){
            text4.gameObject.SetActive(false);
        }
        
        if (timer > 0 && !endState){
            timer -= Time.deltaTime;
        } else {
            endState = true;
            text.color = Color.red;
            //text2.text = "Oh no! Failed!";
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
            if (wordsLeft > 0){
                text2.text = "Oh no! Failed!";
            }

            if (timer2 > 7.5f){
                // get progress to add 1
                if (wordsLeft <= 0){
                    GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
                }
                SceneManager.LoadScene("SalmonNigiriRecipe");
            }
        }
    }

    void spawnWord(){
        //int chosen = Random.Range(0, 26);
        if (chosen != recipeNigiriString.Length-1){
            text2.text = "TYPE: " + recipeNigiriString[chosen] + " " + recipeNigiriString[chosen+1];
        } else {
            text2.text = "TYPE: " + recipeNigiriString[chosen];
        }
        
        chosenWord = recipeNigiriString[chosen];
    }

    void pressed(string s){
        if (doOnce && !endState){
            //Debug.Log("Pressed:" + s);
            if (chosenWord[on].ToString() == s){
                text2.color = new Color(0.125490196f, 0.125490196f, 0.125490196f, 1f);
                //Debug.Log("Equals.");
                on++;
                typedWord = typedWord + s;
                if (typedWord == chosenWord && chosenWord == recipeNigiriString[recipeNigiriString.Length-1] && wordsLeft == 1){
                    // that was the last word.
                    text2.text = "FINISHED! Good Job!";
                    endState = true;
                    wordsLeft--;
                    progressSprite(true);
                }
                else if (typedWord == chosenWord){
                    wordsLeft--;
                    chosen++;
                    on = 0;
                    typedWord = "";
                    spawnWord();
                    progressSprite(true);
                }
            } else {
                //Debug.Log("ResetWord");
                typedWord = "";
                text2.color = Color.red;
                on = 0;
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
        text3.text = "Pieces Left: " + wordsLeft.ToString();
    }

}
