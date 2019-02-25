using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfFood : MonoBehaviour
{
    GameObject[] food;
    int foodCount;
    public GameObject foodItem;
    private float[] shelfPositions;

    List<GameObject> foodList;
    private GameObject[] shoppingList; // put items needed here
    private int[] quantity;  // put quantity of items needed (match index from shopping list above)
   
    // foods
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;

    int foodListLength = 3;


    // Start is called before the first frame update
    void Start()
    {
        shelfPositions = new float[3] { 3.16f, 1.45f, -.8f };
        foodCount = 0;
        food = new GameObject[25];
        Invoke("StockShelf", 0.5f);
        foodList = new List<GameObject> { food1, food2, food3 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject PickRandomFood()
    {
        int randInt = Random.Range(0, foodListLength);
        return foodList[randInt];
    }

    void StockShelf()
    {
        float randomInterval = Random.Range(0.0f, 3.0f);  // can change this random time interval
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
