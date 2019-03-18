using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isHit;
    private string[] shopList;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        isHit = false;
        shopList = ShelfFood.shoppingList;
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
        bool badItem = true;
        if (collision.gameObject.CompareTag("hand"))
        {
            gameObject.layer = 14; // i created a layer called "falling" which is index 14 of the layers
            isHit = true;    

            for (int i = 0; i < shopList.Length; i++)
            {
                if (gameObject.name == ShelfFood.shoppingList[i] && ShelfFood.quantity[i] != 0)
                {
                    badItem = false;
                    ShelfFood.quantity[i] -= 1;
                    ShelfFood.CheckIfDone();
                }
            }
            if (badItem && !ShelfFood.doneShopping)
            {
                Debug.Log("bad");
                ShelfFood.wrongItems += 1;
                if (ShelfFood.lives > 0)
                    ShelfFood.lives -= 1;
            }
        }
    }
}
