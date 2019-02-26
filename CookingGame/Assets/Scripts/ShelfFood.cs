using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShelfFood : MonoBehaviour
{
    GameObject[] food;
    int foodCount;
    public GameObject foodItem;
    private float[] shelfPositions;

    List<GameObject> foodList;
    public static string[] shoppingList; // put items needed here
    public static int[] quantity;  // put quantity of items needed (match index from shopping list above)
    
    
    // foods
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    public GameObject food4;
    public GameObject food5;
    public GameObject food6;
    public GameObject food7;
    public GameObject food8;

    int shoppingListLength;
    int foodListLength = 8;
    public static bool doneShopping = false;

    public Text item1;
    public Text item2;
    public Text item3;
    public Text item4;

    // Start is called before the first frame update
    void Start()
    {
        shelfPositions = new float[3] { 3.16f, 1.45f, -.5f };
        foodCount = 0;
        //food = new GameObject[25];
        Invoke("StockShelf", 0.4f);
        foodList = new List<GameObject> { food1, food2, food3, food4, food5, food6, food7, food8 };
        shoppingList = new string[4]{"pepper(Clone)", "vinegar(Clone)", "salt(Clone)", "pie(Clone)"};
        quantity = new int[4] { 1, 2 , 3, 2 };

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(quantity);
       if (doneShopping)
        {
            Debug.Log("done");
            GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
            SceneManager.LoadScene("SalmonNigiriRecipe");
            Destroy(gameObject) ;
        }
        else
        {
            UpdateList();
        }

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
        item1.text =  quantity[0].ToString() + " bottle of pepper";
        item2.text = quantity[2].ToString() + " bottles of salt";

        item3.text = quantity[3].ToString() + " pies";

        item4.text = quantity[1].ToString() + " bottle of vinegar";

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
