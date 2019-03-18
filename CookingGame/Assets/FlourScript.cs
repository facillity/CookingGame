using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.transform.parent.GetComponent<PickUpItem>().pour == true)
        {
            GetComponent<ParticleSystem>().Play();
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
