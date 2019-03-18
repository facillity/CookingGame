using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fling : MonoBehaviour
{

    Vector2 startPosition, endPosition, direction;
    float clickStart, clickEnd, time, sTime, eTime, dist;
    private bool inAir;
    public float speed = 5f;
    public float jump = 10f;
 

    public float force = .7f;

    // Start is called before the first frame update
    void Start()
    {
        inAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            clickStart = Time.time;
            startPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clickEnd = Time.time;

            time = clickStart - clickEnd;
            endPosition = Input.mousePosition;
            direction = startPosition - endPosition; 
            GetComponent<Rigidbody2D>().AddForce(direction / time * force);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            sTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!inAir)
            {
                dist = (Time.time - sTime) * speed;
                GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x + dist, jump, 1);

            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nigiri"))
        {
            GenerateNigiri.complete = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            float sushiX = gameObject.transform.position.x;
            float riceX = collision.transform.position.x;
            float difference = sushiX - riceX;
            if (difference <= .72f && difference >= .33)
            {
                GenerateNigiri.textDisplay = 0;
            }
            else if (difference >= 0f && difference <= .87f)
            {
                GenerateNigiri.textDisplay = 1;
            }
            else
            {
                GenerateNigiri.textDisplay = 2;
            }
        }
    }
}
