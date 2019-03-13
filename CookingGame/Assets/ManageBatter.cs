using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageBatter : MonoBehaviour
{
    public static bool done, stir;
    public static bool flour, cornstarch, salt, egg;
    public GameObject mix;
    // Start is called before the first frame update
    void Start()
    {
        flour = false;
        cornstarch = false;
        salt = false;
        egg = false;
        stir = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flour && cornstarch && salt && egg)
        {
          
            done = true;
            
        }
    }
}
