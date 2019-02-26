using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShelfFood : MonoBehaviour
{
    GameObject[] food;
    int foodCount;
    public GameObject foodItem;
    private float[] shelfPositions;
    private float timer;

    List<GameObject> foodList;
    public static string[] shoppingList; // put items needed here
    public static int[] quantity;  // put quantity of items needed (match index from shopping list above)
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
        shelfPositions = new float[3] { 3.16f, 1.45f, -.5f };
        foodCount = 0;
        //food = new GameObject[25];
        Invoke("StockShelf", 0.4f);
        foodList = new List<GameObject> { food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11, food12 };
        shoppingList = new string[6]{"soy sauce(Clone)", "vinegar(Clone)", "salt(Clone)", "sushi rice bag(Clone)", "wasabi(Clone)","salmonslab(Clone)"};
        quantity = new int[6] { 4, 3 , 3, 4, 2, 4 };
        timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(quantity);
       UpdateLives();
       if (doneShopping)
        {
            Debug.Log("done");
            GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
            winText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 7f)
            {
                Reset();
                SceneManager.LoadScene("SalmonNigiriRecipe");
            }
            //Destroy(gameObject) ;
        }
       else if (wrongItems >= 3 && !doneShopping)
        {
            Debug.Log("3 wrong items");
            loseText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 7f)
            {
                Reset();
                SceneManager.LoadScene("SalmonNigiriRecipe");
            }
            //Destroy(gameObject);
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
        wrongItems = 0;
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        foodCount = 0;
        lives = 3;
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
        item2.text = quantity[2].ToString();// + " bottles of salt";

        item3.text = quantity[3].ToString();// + " bags of sushi rice";

        item4.text = quantity[5].ToString();// + " pieces of salmon";
        item5.text = quantity[4].ToString();// + " bottles of wasabi";
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
