using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadShrimp : MonoBehaviour
{
    public GameObject shrimp;
    private float timer = 0f;
    public GameObject goodText, okText, perfectText, terribleText;
    public GameObject shrimp1, shrimp2, shrimp3, shrimp4, shrimp5;

    public static float fallSpeed = -1.5f;

    public static int textDisplay = 0;
    public static int shrimpCount = 0;
    private bool shrimpTime = false;

    public static bool nextShrimp = false;
    private bool addOneShrimp = false;
    // Start is called before the first frame update
    void Start()
    {
        perfectText.SetActive(false);
        goodText.SetActive(false);
        okText.SetActive(false);
        terribleText.SetActive(false);
        shrimpCount = 0;
        GenerateShrimp();
    }

    private void GenerateShrimp()
    {
        nextShrimp = false;
        Instantiate(shrimp, new Vector3(2.54f, 3.4f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextShrimp)
        {
            DisplayText();
            AddShrimpToPile();
            timer += Time.deltaTime;
            nextShrimp = false;
            shrimpTime = true;
        }
        if (shrimpTime)
        {
            timer += Time.deltaTime;
        }
        if (timer > 1.5f && shrimpTime)
        {
            ClearText();
            Debug.Log("here in timer");
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("shrimp");
            for (int i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }
            GenerateShrimp();
            timer = 0f;
            shrimpTime = false;
           
        }
    }

    void DisplayPerfectText()
    {
        perfectText.SetActive(true);
    }

    void DisplayTerribleText()
    {
        terribleText.SetActive(true);
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
        terribleText.SetActive(false);
    }

    void DisplayText()
    {
        if (textDisplay == 0)
        {
            DisplayPerfectText();
        }
        else if (textDisplay == 1)
        {
            DisplayGoodText();
        }
        else if (textDisplay == 2)
        {
            DisplayOkText();
        }
        else
            DisplayTerribleText();
    }

    void AddShrimpToPile()
    {
        if (textDisplay == 1 || textDisplay == 0)
        {
            shrimpCount += 1;
            fallSpeed -= 1.5f;
        }

        if (shrimpCount == 1)
            shrimp1.SetActive(true);
        else if (shrimpCount == 2)
            shrimp2.SetActive(true);
        else if (shrimpCount == 3)
            shrimp3.SetActive(true);
        else if (shrimpCount == 4)
            shrimp4.SetActive(true);
        else if (shrimpCount == 5)
            shrimp5.SetActive(true);
    }
}
