using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSushiRice : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isHit;
    public static float speed = 2f;
    public bool left;
    //private string[] shopList;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        isHit = false;
        left = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (left)
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * -speed;
        else
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

    }

    private void FixedUpdate()
    {
        if (transform.position.x < -9)
        {
            Destroy(gameObject);
            if (ManageSushiRice.lives > 0 && !ManageSushiRice.won)
            {
                ManageSushiRice.lives -= 1;
            }
        }
        else if (transform.position.x > 13)
        {
            Destroy(gameObject);
        }
    }
}
