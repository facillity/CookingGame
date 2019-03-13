using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixBatter : MonoBehaviour
{
    public static bool doneMixing = false;
    private float[] red = { 254, 253, 252, 251, 250, 249, 248 };
    private float[] green = { 247, 241, 234, 227, 221, 214, 207 };////228,248,214,201};
    private float[] blue = { 231, 206, 182, 157, 133, 108, 84 };//153,230,102,51};
    private int mixAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 1,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked c");
            if(!doneMixing)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(1, green[mixAmount]/255, blue[mixAmount]/255);
                mixAmount++;
            }
            if (mixAmount == 7)
            {
                doneMixing = true;
            }
            
        }
    }
}
