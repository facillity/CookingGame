using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeLogic : MonoBehaviour
{

    public Transform knifeTransform;
    public Rigidbody2D rigidBody;
    public bool canStartMoving;
    public int knifeSpeed;
    private int directionMoving; //0 nowhere, 1 right, 2 left

    // Start is called before the first frame update
    void Start()
    {
        knifeTransform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        canStartMoving = false;
        knifeSpeed = 5;
        directionMoving = 0;
    }


    private void moveRight()
    {
        rigidBody.velocity = new Vector2(knifeSpeed, 0);
        directionMoving = 1;
    }

    private void moveLeft()
    {
        rigidBody.velocity = new Vector2(-knifeSpeed, 0);
        directionMoving = 2;
    }

    public void stopKnife()
    {
        rigidBody.velocity = new Vector2(0, 0);
        directionMoving = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canStartMoving)
        {
            if (directionMoving == 0)
            {
                moveRight();
            }
            else if (knifeTransform.position.x >= 5.5)
            {
                moveLeft();
            }
            else if (knifeTransform.position.x <= -5.5)
            {
                moveRight();
            }
        }
        else
        {
            stopKnife();
        }
    }
}
