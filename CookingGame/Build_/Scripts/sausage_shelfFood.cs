﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sausage_shelfFood : MonoBehaviour
{
    GameObject[] food;
    int foodCount;
    public GameObject foodItem;
    private float[] shelfPositions;
    private float timer;
    private bool cheated = false;

    List<GameObject> foodList;
    public static string[] shoppingList; // put items needed here
    public static List<int> quantity = new List<int>();
    public static int wrongItems = 0;
    
    // foods
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    public GameObject food4;
    public GameObject food5;
    public GameObject food6;
    public GameObject food7;
    public GameObject food8;
    public GameObject food9;
    public GameObject food10;
    public GameObject food11;
    public GameObject food12;

    int shoppingListLength;
    int foodListLength = 12;
    public static bool doneShopping = false;

    public Text item1;
    public Text item2;
    public Text item3;
    public Text item4;
    public Text item5;
    public Text item6;

    public Text loseText;
    public Text winText;
    public Text livesText;

    public static int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        cheated = false;
        shelfPositions = new float[3] { 3.16f, 1.45f, -.5f };
        foodCount = 0;
        //food = new GameObject[25];
        Invoke("StockShelf", 0.4f);
        foodList = new List<GameObject> { food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11, food12 };
        shoppingList = new string[2]{"eggs(Clone)", "sausages(Clone)"};
        //quantity = new int[6] { 2, 1 , 3, 4, 2, 3 };
        for (int idx = 0; idx < 2; idx++){
            quantity.Add(Random.Range(1, 4));
        }
        timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (ProgressScript.cheats && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C)){
            Debug.Log("SKIPPED.");
            cheated = true;
            doneShopping = true;
        }
        // Debug.Log(quantity);
       UpdateLives();
       if (doneShopping || cheated)
        {
            UpdateList();
            winText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 7f)
            {
                Reset();
                GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
                SceneManager.LoadScene("BreakfastRecipe");
            }
        }
       else if (wrongItems >= 3 && !doneShopping && !cheated)
        {
            Debug.Log("3 wrong items");
            loseText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 7f) 
            {
                Reset();
                SceneManager.LoadScene("BreakfastRecipe");
            }
        }
        else
        {
            UpdateList();
        }

    }


    private void UpdateLives()
    {
        livesText.text = "Lives: " + lives.ToString();
    }


    private void Reset()
    {
        cheated = false;
        quantity.Clear();
        wrongItems = 0;
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        foodCount = 0;
        lives = 3;
        for (int idx = 0; idx < 2; idx++){
            quantity.Add(Random.Range(1, 4));
        }
        timer = 0f;
    }

    public static void CheckIfDone()
    {
        for (int i = 0; i < shoppingList.Length; i++)
        {
            if (quantity[i] != 0)
            {
                doneShopping = false;
                return;
            }

        }
        doneShopping = true;
    }

    private void UpdateList()
    {
        item1.text = quantity[0].ToString();// + " bottle of soy sauce";
        //item2.text = quantity[2].ToString();// + " bottles of salt";

        //item3.text = quantity[3].ToString();// + " bags of sushi rice";

        //item4.text = quantity[5].ToString();// + " pieces of salmon";
        //item5.text = quantity[4].ToString();// + " bottles of wasabi";
        item6.text = quantity[1].ToString();// + " bottle of vinegar";

    }

    GameObject PickRandomFood()
    {
        int randInt = Random.Range(0, foodListLength);
        return foodList[randInt];
    }

    void StockShelf()
    {
        float randomInterval = Random.Range(0.0f, 2.0f);  // can change this random time interval
        StockRandomShelf();
        Invoke("StockShelf", randomInterval);
    }

    void StockRandomShelf()
    {
        int randShelf = Random.Range(0, 3);
        GameObject randFood = PickRandomFood();
        Instantiate(randFood, new Vector3(14f, shelfPositions[randShelf], 0), Quaternion.identity);
        foodCount++;
    }

}
