using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrimp : MonoBehaviour
{
    public Camera cam;
    public Sprite cookingSprite;
    Vector3 mousePos;
    Vector2 mousePos2D;
    Vector2 InitPos;
    int speed = 4;
    bool isPickedUp = false;
    bool isCooking = false;
    bool isCooked = false;
    bool isFinished = false;

    void Start()
    {
        InitPos = new Vector2(Random.Range(3f, 5f),Random.Range(3f,5f));
        this.transform.position = InitPos;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
            if (hit.Length >= 2)
            {
                
                Debug.Log(hit[1].collider.gameObject.tag);
            }
            if (!isPickedUp)
            { 
                if (hit.Length>=1 && hit[0].collider.gameObject == this.gameObject)
                {
                    Debug.Log(hit[0].collider.gameObject.name);
                    isPickedUp = true;
                }
            }
            else if(hit.Length>=2 && hit[1].collider.gameObject.CompareTag("fryer slot") && !isCooked)
            {
                isPickedUp = false;
                this.GetComponent<SpriteRenderer>().sprite = cookingSprite;
                isCooked = true;
            }
            else if (isCooked && hit.Length>=2 && hit[0].collider.gameObject.CompareTag("Board"))
            {
                isPickedUp = false;
                isFinished = true;
            }
        }
        if(isPickedUp)
        {
            this.transform.position = mousePos2D;
        }

    }

    
}

