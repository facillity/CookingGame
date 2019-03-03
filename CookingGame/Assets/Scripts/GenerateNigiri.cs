using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateNigiri : MonoBehaviour
{
    public GameObject salmon;
    public GameObject rice;
    public static bool complete = false;
    public static float timer = 0f;
    public GameObject goodText, okText, perfectText;

    public static int textDisplay = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        GenerateIngredients();
        perfectText.SetActive(false);
        goodText.SetActive(false);
        okText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (complete)
        {
            DisplayText();
            timer += Time.deltaTime;
        }
        if (timer > 1f)
        {
            ClearText();
            Debug.Log("here in timer");
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("nigiri");
            for (int i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }
            GenerateIngredients();
            timer = 0f;
        }
    }

    void GenerateIngredients()
    {
        float ricePosX = Random.Range(-5.84f, 7.4f);
        float ricePosY = Random.Range(-1.96f, 1.97f);
        float salmonPosX = Random.Range(-5.84f, 7.4f);
      
        Instantiate(salmon, new Vector3(salmonPosX, -4.5f,0), Quaternion.identity);
        Instantiate(rice, new Vector3(ricePosX,ricePosY,0), Quaternion.identity);
        complete = false;
    }


    void DisplayText()
    {
        if (textDisplay == 0)
            DisplayPerfectText();
        else if (textDisplay == 1)
            DisplayGoodText();
        else
            DisplayOkText();
    //    float time = 0f;
   //     while (time < 2.0f)
    //        time += Time.deltaTime;
    //    ClearText();
    }

    void DisplayPerfectText()
    {
        perfectText.SetActive(true);
    }

    void DisplayGoodText()
    {
        goodText.SetActive(true);
    }

    void DisplayOkText()
    {
        okText.SetActive(true);
    }

    void ClearText()
    {
        perfectText.SetActive(false);
        goodText.SetActive(false);
        okText.SetActive(false);
    }


}
