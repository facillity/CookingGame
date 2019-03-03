using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fling : MonoBehaviour
{

    Vector2 startPosition, endPosition, direction;
    float clickStart, clickEnd, time;

    public float force = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rice"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
}
