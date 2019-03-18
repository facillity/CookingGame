using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickUpItem : MonoBehaviour
{
    public Camera cam;
    public GameObject mix, egg;
    Vector3 mousePos;
    Vector2 mousePos2D;
    Vector2 InitPos;
    int speed = 4;
    bool isPickedUp = false;
    bool followMouse = false;
    public bool pour = false;
    Rigidbody2D rb;
    public Sprite newObj;
    public GameObject newGameObject;
    private float z = 0;
    public GameObject salmon;
    private bool createSalmon = true;
    private bool stopMovement = false;
    private bool speedChange = false;
    private bool mixed = false;
    private bool turned = false;
    private float turn = 90f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!this.gameObject.CompareTag("crackedegg"))
            rb.isKinematic = true;
        pour = false;
  
    }  

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Vector3 pos = Input.mousePosition;
        RaycastHit2D[] hit = null;

        
        if (Input.GetMouseButtonDown(0) && !isPickedUp && !speedChange && !gameObject.CompareTag("crackedegg"))
        {
            hit = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
            if (!isPickedUp && hit.Length >= 1 && hit[0].collider.gameObject == this.gameObject)
            {
                if (hit[0].collider.gameObject.CompareTag("salmon") && createSalmon)
                {
                    Instantiate(salmon, new Vector3(hit[0].collider.gameObject.transform.position.x, hit[0].collider.gameObject.transform.position.y, 1), Quaternion.identity);
                    createSalmon = false;
                }

                isPickedUp = true;
                rb.isKinematic = true;
                z = hit[0].collider.gameObject.transform.position.z;
}

        }
        else if (Input.GetMouseButtonDown(0) && isPickedUp)
        {
            hit = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
            if (hit.Length >= 2)
                Debug.Log(hit[1].collider.gameObject.tag);
            if (gameObject.CompareTag("salmon") && hit.Length >= 2 && hit[1].collider.gameObject.CompareTag("nigiri"))
            {
                rb.isKinematic = true;
                Destroy(gameObject.GetComponent<BoxCollider2D>());

                hit[0].transform.position = new Vector3(hit[1].transform.position.x - .12f, hit[1].transform.position.y + .689f, -1);
                hit[0].transform.parent = hit[1].transform;
                hit[1].transform.gameObject.AddComponent<PickUpItem>();

                stopMovement = true;
                isPickedUp = false;
            }
            if (gameObject.CompareTag("whisk") && ManageBatter.done && !mixed)
            {
                ManageBatter.stir = true;
                mix.SetActive(true);
                GameObject[] egg;
                egg = GameObject.FindGameObjectsWithTag("crackedegg");
                mixed = true;
                Destroy(egg[0]);
            }
            if (gameObject.CompareTag("nigiri") && hit.Length >= 2 && hit[1].collider.gameObject.CompareTag("conveyer"))
            {
                if (!speedChange)
                {
                    ManageSushiRice.sushiLeft -= 1;
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, -0.6352668f, -1);
                    gameObject.GetComponent<MoveSushiRice>().left = false; 
                    speedChange = true;
                    isPickedUp = false;
                }
          
            }
            else if (!turned && !gameObject.CompareTag("salmon") && !gameObject.CompareTag("nigiri") && !(gameObject.CompareTag("whisk") && ManageBatter.done))
            {
                rb.isKinematic = false;
                isPickedUp = false;
            }
            Debug.Log(ManageBatter.done);


            if (gameObject.CompareTag("egg") && hit.Length >= 2 && hit[1].collider.gameObject.CompareTag("bowl"))
            {
                GameObject newObject = (GameObject)EditorUtility.InstantiatePrefab(newGameObject);
                newObject.transform.position = gameObject.transform.position;
                newObject.transform.rotation = gameObject.transform.rotation;
                ManageBatter.egg = true;
                Destroy(gameObject);
            }


        }
        else if (Input.GetMouseButtonDown(1) && !gameObject.CompareTag("egg") && isPickedUp)
        {
            turned = !turned;
            hit = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
            if (gameObject.CompareTag("whisk"))
            {
                turn = 50;
            }

            if (hit.Length >= 1 && hit[0].collider.gameObject == this.gameObject)
            {
                if (!pour)
                    gameObject.transform.Rotate(Vector3.forward * -turn);
                else
                    gameObject.transform.Rotate(Vector3.forward * turn);
                pour = !pour;
            }
        }
        else if (isPickedUp)
        {
            this.transform.position = new Vector3(mousePos2D.x, mousePos2D.y, z);// mousePos2D;
        }

        if (turned && Input.GetMouseButtonUp(0) && pour)
        {
            if (gameObject.CompareTag("flour"))
            {
                ManageBatter.flour = true;
            }
            if (gameObject.CompareTag("cornstarch"))
            {
                ManageBatter.cornstarch = true;
            }
            if (gameObject.CompareTag("salt"))
            {
                ManageBatter.salt = true;
            }
            if (gameObject.CompareTag("water"))
            {
                ManageBatter.water = true;
            }

        }





    }


}

