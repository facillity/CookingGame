using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHit)
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * -5f;
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * -.1f;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.up * -3f;
        }
            
    }

    private void FixedUpdate()
    {
        if (transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hand"))
        {
            gameObject.layer = 10; // i created a layer called "falling" which is index 10 of the layers
            isHit = true;    
        }
    }
}
