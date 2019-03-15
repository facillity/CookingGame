using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirringIceCream : MonoBehaviour
{
    
    int lenience;
    float stirSpeed;
    public GameObject IceCream;

    private void Awake()
    {
        stirSpeed = 10.0F;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            this.transform.localScale += new Vector3(10, 0, 0);
            //IceCream.GetComponent<Rigidbody2D>().MoveRotation(IceCream.GetComponent<Rigidbody2D>().rotation + stirSpeed * Time.fixedDeltaTime);
            IceCream.GetComponent<Rigidbody2D>().AddTorque(stirSpeed, ForceMode2D.Force);// * IceCream.GetComponent<Transform>().transform.up);
        }
        if (transform.localScale.x >= 0)
        {
            this.transform.localScale -= new Vector3(1.1F, 0, 0);
        }
    }
}
