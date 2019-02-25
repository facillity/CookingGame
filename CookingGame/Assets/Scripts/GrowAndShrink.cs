using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAndShrink : MonoBehaviour
{

    public float speed = 0.005f;
    public float minSize = 1;
    public float maxSize = 1.2f;
    public float currentSize;
    public bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
         currentSize = 1;
         goingUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.localScale;

        if (goingUp){
            currentSize += speed;
        } else {
            currentSize -= speed;
        }

        temp.y = currentSize;
        temp.x = currentSize;

        if (currentSize > maxSize){
            goingUp = false;
        } else if (currentSize < minSize){
            goingUp = true;
        }

        transform.localScale = temp;
    }
}
