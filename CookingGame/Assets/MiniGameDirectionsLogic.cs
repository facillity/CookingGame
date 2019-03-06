using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameDirectionsLogic : MonoBehaviour
{
    public Text gameTitle;
    public Text gameDescription;
    public Image gameImage;
    public GameObject Keyboard;
    public GameObject Mouse;
    public GameObject ArrowKeys;
    public Sprite salmonNigiri1;
    public Sprite salmonNigiri2;
    public Sprite salmonNigiri3;

    void Update(){
        if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 0){
            gameTitle.text = "Gather Items";
            gameDescription.text = "Move the hand using up arrow and down arrow to get all the items on your shopping list! Be careful not to get too many wrong items or more items than you need!";
            gameImage.GetComponent<Image>().sprite = salmonNigiri1;
            Keyboard.SetActive(false);
            Mouse.SetActive(false);
            ArrowKeys.SetActive(true);
        }

        if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 1){
            gameTitle.text = "Cut Salmon";
            gameDescription.text = "Type the recipe given to you on the bottom of the screen! You have 60 seconds to do it!";
            gameImage.GetComponent<Image>().sprite = salmonNigiri2;
            Keyboard.SetActive(true);
            Mouse.SetActive(false);
            ArrowKeys.SetActive(false);
        }

        if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 2){
            gameTitle.text = "Vinegar & Rice";
            gameDescription.text = "Pay attention to the order of the arrows that come out on the screen! Repeat them to fill up the rice pot!";
            gameImage.GetComponent<Image>().sprite = salmonNigiri3;
            Keyboard.SetActive(false);
            Mouse.SetActive(true);
            ArrowKeys.SetActive(false);
        }

        if (Input.GetKeyDown("space")){
            if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 0){
                SceneManager.LoadScene("minigame1");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 1){
                SceneManager.LoadScene("SalmonCutting");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 2){
                SceneManager.LoadScene("VinegarRiceMinigame");
            }
        }
    }
}
