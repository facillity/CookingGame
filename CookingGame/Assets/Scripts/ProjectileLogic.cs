using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
 
{
    public float speed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {  
    }
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.up * 5f;
    }


    private void FixedUpdate()
    {
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
