﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShrimpMinigameDirections : MonoBehaviour
{
    public Text gameTitle;
    public Text gameDescription;
    public Image gameImage;
    public GameObject Keyboard;
    public GameObject Mouse;
    public GameObject ArrowKeys;
    public Sprite shrimp1;
    public Sprite shrimp2;
    public Sprite shrimp3;
    public Sprite shrimp4;

    void Update(){
        if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 0){
            
            gameTitle.text = "Gather Items";
            gameDescription.text = "Move the hand using up arrow and down arrow to get all the items on your shopping list! Be careful not to get too many wrong items or more items than you need!";
            gameImage.GetComponent<Image>().sprite = shrimp1;
            Keyboard.SetActive(false);
            Mouse.SetActive(false);
            ArrowKeys.SetActive(true);
            
        }

        if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 1){
            
            gameTitle.text = "Mixing Time";
            gameDescription.text = "Using the mouse, grab each of the ingredients, tilt them using right click and add them into the bowl using left click. Then take the whisk and mix it up using left click!";
            gameImage.GetComponent<Image>().sprite = shrimp2;
            Keyboard.SetActive(false);
            Mouse.SetActive(true);
            ArrowKeys.SetActive(false);
        }

        if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 2){
            gameTitle.text = "Battering";
            gameDescription.text = "Press spacebar to stop the shrimp from going completely into the batter. The closer you get to the tail, the better!";
            gameImage.GetComponent<Image>().sprite = shrimp3;
            Keyboard.SetActive(true);
            Mouse.SetActive(false);
            ArrowKeys.SetActive(false);
        }

        if(GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 3)
        {
            gameTitle.text = "Frying";
            gameDescription.text = "Click and drag the shrimp into the fryer. Wait until they're done as shown with a green time bar. When they're done, put them on the left. Be careful not to burn them!";
            gameImage.GetComponent<Image>().sprite = shrimp4;
            Keyboard.SetActive(false);
            Mouse.SetActive(true);
            ArrowKeys.SetActive(false);
        }

        if (Input.GetKeyDown("space")){
            if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 0){
                SceneManager.LoadScene("ShrimpShopping");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 1){
                SceneManager.LoadScene("ShrimpTempuraFlour");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 2){
                SceneManager.LoadScene("ShrimpTempuraBatter");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 3){
                SceneManager.LoadScene("Minigame4");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 2){
                SceneManager.LoadScene("end_screens");
            }
        }
    }
}
