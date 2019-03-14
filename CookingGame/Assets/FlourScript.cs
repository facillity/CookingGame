using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<ParticleSystem>().emissionRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.transform.parent.GetComponent<PickUpItem>().pour == true)
        {
            GetComponent<ParticleSystem>().Play();
            // GetComponent<ParticleSystem>().emissionRate = 10;
        }
        if (Input.GetMouseButtonUp(0) && this.transform.parent.GetComponent<PickUpItem>().pour == true)
        {
            GetComponent<ParticleSystem>().Stop();
        }
        if (ManageBatter.stir)
        {
            Destroy(gameObject);
        }
    }
}
