using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public GameObject topHand;
    public GameObject midHand;
    public GameObject lowHand;

    int current = 0;
    // Start is called before the first frame update
    void Start()
    {
        topHand.SetActive(false);
        midHand.SetActive(true);
        lowHand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDown();
        }
    }

    private void moveUp()
    {
        if (current == -1)
        {
            current = 0;
            midHand.SetActive(true);
            lowHand.SetActive(false);
        }
        else if (current == 0)
        {
            current = 1;
            topHand.SetActive(true);
            midHand.SetActive(false);
        }
    }

    private void moveDown()
    {
        if (current == 0)
        {
            current = -1;
            midHand.SetActive(false);
            lowHand.SetActive(true);
        }
        else if (current == 1)
        {
            current = 0;
            topHand.SetActive(false);
            midHand.SetActive(true);
        }
    }
}
