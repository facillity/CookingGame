using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VinegarGameLogic : MonoBehaviour
{
    public GameObject arrow1;
    public GameObject arrow2;
    public Text potText;
    public Text livesText;
    public Text directions;
    public float timer;
    public float timer2;
    public float timer3;
    public int lives;
    public bool pauseTimer;
    public bool firstGame;
    public bool secondGame;
    public bool thirdGame;
    public bool inputTime;
    public Button leftBtn;
    public Button rightBtn;
    public List<int> arrows = new List<int>();
    public static List<int> givenArrows = new List<int>();

    public SpriteRenderer pot;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public bool endState;

    // Start is called before the first frame update
    void Start()
    {
        endState = false;
        firstGame = true;
        secondGame = false;
        thirdGame = false;
        pauseTimer = false;
        lives = 3;
        timer = 0f;
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        leftBtn.gameObject.SetActive(false);
        rightBtn.gameObject.SetActive(false);
        potText.text = "0%";
        livesText.text = "Lives: " + lives.ToString();
    }

    void Restart(){
        endState = false;
        firstGame = true;
        secondGame = false;
        thirdGame = false;
        pauseTimer = false;
        timer = 0f;
        lives = 3;
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        leftBtn.gameObject.SetActive(false);
        rightBtn.gameObject.SetActive(false);
        potText.text = "0%";
        livesText.text = "Lives: " + lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseTimer){
            timer += Time.deltaTime;
        } else {
            timer2 += Time.deltaTime;
        }

        // end state logic
        if (endState){
            timer3 += Time.deltaTime;

            if (timer3 > 7.5f){
                // get progress to add 1
                if (lives > 0){
                    GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
                }
                Restart();
                SceneManager.LoadScene("SalmonNigiriRecipe");
            }
        }

        if (firstGame && !endState){
            if (timer > 0){
                directions.text = "Round 1";
            }
            if (timer > 2){
                directions.text = "Ready?";
            }
            if (timer > 4){
                directions.text = "Pay attention!";
            }
            if (timer > 6){
                directions.text = "";
                pauseTimer = true;
                timer = 0f;
                timer2 = 0f;
                firstScene();
            }
        }

        if (secondGame && !endState){
            if (timer > 0){
                directions.text = "Round 2";
            }
            if (timer > 2){
                directions.text = "Ready?";
            }
            if (timer > 4){
                directions.text = "Pay attention!";
            }
            if (timer > 6){
                directions.text = "";
                pauseTimer = true;
                timer = 0f;
                timer2 = 0f;
                secondScene();
            }
        }

        if (thirdGame && !endState){
            if (timer > 0){
                directions.text = "Round 3";
            }
            if (timer > 2){
                directions.text = "Ready?";
            }
            if (timer > 4){
                directions.text = "Pay attention!";
            }
            if (timer > 6){
                directions.text = "";
                pauseTimer = true;
                timer = 0f;
                timer2 = 0f;
                thirdScene();
            }
        }

        if (timer2 > 1 && timer2 <= 1.5){
            playArrows(arrows[0]);
        } else if (timer2 > 1.5 && timer2 <= 2){
            clearArrows();
        } else if (timer2 > 2 && timer2 <= 2.5){
            playArrows(arrows[1]);
        } else if (timer2 > 2.5 && timer2 <= 3){
            clearArrows();
        } else if (timer2 > 3 && timer2 <= 3.5){
            playArrows(arrows[2]);
        } else if (timer2 > 3.5 && timer2 <= 4){
            clearArrows();
        } else if (timer2 > 4 && timer2 <= 4.5){
            playArrows(arrows[3]);
        } else if (timer2 > 4.5 && timer2 <= 5){
            clearArrows();
        } else if (timer2 > 5 && timer2 <= 5.5){
            playArrows(arrows[4]);
        } else if (timer2 > 5.5 && timer2 <= 6){
            clearArrows();
        } else if (timer2 > 6 && timer2 <= 6.5){
            playArrows(arrows[5]);
        } else if (timer2 > 6.5 && timer2 <= 7){
            clearArrows();
        }

        if (timer2 > 7){
            leftBtn.gameObject.SetActive(true);
            rightBtn.gameObject.SetActive(true);
            // able to click so check stuff
            if (givenArrows.Count == 6){
                leftBtn.gameObject.SetActive(false);
                rightBtn.gameObject.SetActive(false);
                timer2 = 0;
                pauseTimer = false;
                if (arrows[0] == givenArrows[0] && arrows[1] == givenArrows[1] && arrows[2] == givenArrows[2] && arrows[3] == givenArrows[3]
                    && arrows[4] == givenArrows[4] && arrows[5] == givenArrows[5]){
                        if (firstGame){
                            firstGame = false;
                            secondGame = true;
                            potText.text = "33%";
                            pot.sprite = s1;
                        } else if (secondGame){
                            secondGame = false;
                            thirdGame = true;
                            potText.text = "66%";
                            pot.sprite = s2;
                        } else if (thirdGame){
                            thirdGame = false;
                            potText.text = "100%";
                            pot.sprite = s3;
                            directions.text = "All Done! Nice Work!";
                            endState = true;
                        }
                    }
                else {
                    Debug.Log("Wrong");
                    lives -= 1;
                    livesText.text = "Lives: " + lives.ToString();
                    if (lives == 0){
                        directions.text = "Oh no! You lost!";
                        Debug.Log("LOST!");
                        endState = true;
                    }
                }
                arrows.Clear();
                givenArrows.Clear();
            }
        }
    }

    public static void addLeft(){
        givenArrows.Add(0);
    }

    public static void addRight(){
        givenArrows.Add(1);
    }

    void playArrows(int c){
        if (c == 0){
            arrow1.SetActive(true);
        } else if (c == 1){
            arrow2.SetActive(true);
        }
    }

    void clearArrows(){
        arrow1.SetActive(false);
        arrow2.SetActive(false);
    }

    void firstScene(){
        for (int idx = 0; idx < 6; idx++){
            arrows.Add(Random.Range(0, 2));
        }
        //Debug.Log(arrows.ToString());
    }

    void secondScene(){
        firstScene();
    }

    void thirdScene(){
        secondScene();
    }


}
