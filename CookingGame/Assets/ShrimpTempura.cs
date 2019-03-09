using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpTempura : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.up * ReloadShrimp.fallSpeed;//-2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            float pos = gameObject.transform.position.y;
            Debug.Log(pos);
            if (pos < -1.25f && pos > -1.7f)
            {
                ReloadShrimp.textDisplay = 2;
            }
            else if (pos <= -1.7f && pos > -2.18f)
            {
                ReloadShrimp.textDisplay = 1;
            }
            else if (pos <= -2.18f && pos >= -2.48f)
            {
                ReloadShrimp.textDisplay = 0;
            }
            else
                ReloadShrimp.textDisplay = -1;
            ReloadShrimp.nextShrimp = true;
        }
        if (transform.position.y < -6f)
        {
            ReloadShrimp.textDisplay = -1;
            ReloadShrimp.nextShrimp = true;
        }
    }
}
