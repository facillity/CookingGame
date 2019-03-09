using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().emissionRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<ParticleSystem>().emissionRate = 10;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<ParticleSystem>().emissionRate = 0;
        }
    }
}
