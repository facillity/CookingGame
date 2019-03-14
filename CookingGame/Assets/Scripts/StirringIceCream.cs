using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirringIceCream : MonoBehaviour
{
    
    int lenience;

    private void Awake()
    {
       
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
        }
        if (transform.localScale.x >= 0)
        {
            this.transform.localScale -= new Vector3(1.1F, 0, 0);
        }
    }
}
