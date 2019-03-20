using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_item2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isHit;
    private string[] shopList;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        isHit = false;
        shopList = sausage_shelfFood.shoppingList;
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
            shopList = sausage_shelfFood.shoppingList;
            for (int i = 0; i < shopList.Length; i++)
            {
                Debug.Log(gameObject.name);
                Debug.Log(sausage_shelfFood.shoppingList[i]);
                Debug.Log(sausage_shelfFood.quantity[i]);
                if (gameObject.name == sausage_shelfFood.shoppingList[i] && sausage_shelfFood.quantity[i] != 0)
                {
                    badItem = false;
                    sausage_shelfFood.quantity[i] -= 1;
                    sausage_shelfFood.CheckIfDone();
                }
            }
            if (badItem && !sausage_shelfFood.doneShopping)
            {
                Debug.Log("bad");
                sausage_shelfFood.wrongItems += 1;
                if (sausage_shelfFood.lives > 0)
                    sausage_shelfFood.lives -= 1;
            }
        }
    }
}
