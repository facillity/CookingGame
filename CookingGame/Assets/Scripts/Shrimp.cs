using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrimp : MonoBehaviour
{
    public Camera cam;
    public Sprite standardSprite;
    public Sprite cookingSprite;
    public Sprite burntSprite;
    public GameObject progressBar;
    public GameObject gameManager;
    Vector3 mousePos;
    Vector2 mousePos2D;
    Vector2 InitPos;
    int speed = 4;
    int initCookTime;
    bool isPickedUp = false;
    bool isCooking = false;
    bool isCooked = false;
    bool notDone = false;
    bool doOnce = false;
    public bool isBurnt = false;
    public bool isFinished = false;
    //public static Shrimp instance;
    

    void Start()
    {
        //InitPos = new Vector2(Random.Range(3f, 5f),Random.Range(3f,5f));
        //this.transform.position = InitPos;
        //instance = this;
        InitPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
            if (!isPickedUp)
            { 
                if (hit.Length>=1 && hit[0].collider.gameObject == this.gameObject && !notDone)
                {
                    isPickedUp = true;
                    if(isCooked)
                    {
                        isCooking = false;
                    }
                }
            }
            else if(!isCooking && hit.Length>=2 && hit[1].collider.gameObject.CompareTag("fryer slot") && !isCooked)
            {
                isPickedUp = false;
                isCooking = true;
                //isCooked = true;
                initCookTime = (int)Time.time;
            }
            else if (isCooked && hit.Length>=2 && hit[0].collider.gameObject.CompareTag("Board"))
            {
                isPickedUp = false;
                if (!isBurnt)
                {
                    isFinished = true;
                }
            }
        }
        if(isCooking)
        {
            cook(initCookTime);
        }
        if(isPickedUp)
        {
            this.transform.position = mousePos2D;
        }

    }

    void cook(int initTime)
    {
        notDone = true;
        int temp = (int)Time.time;
        progressBar.SetActive(true);
        if ((int)Time.time == (int)initTime + 1)
        {
            progressBar.gameObject.transform.localScale = new Vector3(0.45F, 0.644F, 0);
        }
        else if((int)Time.time == (int)initTime + 2)
        {
            progressBar.gameObject.transform.localScale = new Vector3(0.225F, 0.644F, 0);
        }
        else if((int)Time.time == (int)initTime+3)
        {
            notDone = false;
            progressBar.gameObject.transform.localScale = new Vector3(0F, 0.644F, 0);
            isCooked = true;
            this.GetComponent<SpriteRenderer>().sprite = cookingSprite;
        }
        else if((int)Time.time == (int)initTime + 5)
        {
            notDone = false;
            isBurnt = true;
            this.GetComponent<SpriteRenderer>().sprite = burntSprite;
            if (!doOnce)
            {
                gameManager.GetComponent<ShrimpSpawner>().loseLife();
                doOnce = true;
            }
            isCooked = true;
        }
    }

    public void Reset()
    {
        this.transform.position = InitPos;
        this.GetComponent<SpriteRenderer>().sprite = standardSprite;
        isFinished = false;
        isCooked = false;
        isBurnt = false;
        notDone = true;
    }
}

