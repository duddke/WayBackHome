using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float speed = 3;
    public bool dirRight = true;
    float origintPosition;
    public float roundRange = 5;
    public bool playerChecked = false;
    PlayerMove pm;
    
    // Start is called before the first frame update
    void Start()
    {
        origintPosition = transform.position.z;
        pm = PlayerMove.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(dirRight)
        {
            goRight();
            if(transform.position.z >= origintPosition + roundRange)
            {
                dirRight = false;
            }
        }

        if (!dirRight)
        {
            goLeft();
            if (transform.position.z <= origintPosition - roundRange)
            {
                dirRight = true;

            }
        }
    }

    private void goLeft()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
        if (playerChecked)
        {
            //print("2");
           pm.onMovingBlock(new Vector3(0, pm.yVelocity,-1) * speed * Time.deltaTime);
           //pm.onMovingBlock(Vector3.left * speed * Time.deltaTime);
        }

    }

    private void goRight()
    {
        
        transform.position += Vector3.forward * speed * Time.deltaTime;
        if (playerChecked)
        {
            pm.onMovingBlock(new Vector3(0, pm.yVelocity, 1) * speed * Time.deltaTime);
           // pm.onMovingBlock(Vector3.right * speed * Time.deltaTime);
        }
    }
}
