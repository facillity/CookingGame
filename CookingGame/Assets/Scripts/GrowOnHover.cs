using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOnHover : MonoBehaviour
{
    bool doOnce = false;
    public float scaleFactor = 1.5f;
    public void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (!doOnce)
        {
            transform.localScale = new Vector3(transform.localScale.x * scaleFactor, transform.localScale.y * scaleFactor, transform.localScale.z * scaleFactor);
            doOnce = true;
        }    
    }

    public void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x / scaleFactor, transform.localScale.y / scaleFactor, transform.localScale.z / scaleFactor);
        doOnce = false;
    }
}
