using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlock : MonoBehaviour
{
    public bool isChecked = false;
    public float speed = 20;
    public float radius = 10;
    public float startTime;
    Vector3 rotatePoint;
    Vector3 originPosition;
    // Start is called before the first frame update
    void Start()
    {
        rotatePoint = transform.position + new Vector3(0, radius, 0);
        originPosition = transform.position;
        prevPos = transform.position;
    }
    Vector3 prevPos;
    

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(speed, 0, 0) * Time.deltaTime);
        Invoke("rotate",startTime);
            rotate();
        
            Vector3 gap = transform.position - prevPos;
            gap.x = gap.y = 0;  
            if(isChecked == true)
            {
                
                PlayerMove.instance.onMovingBlock(gap);
            } 
            prevPos = transform.position;
        
    }

    private void rotate()
    {
        transform.RotateAround(rotatePoint, Vector3.right, speed * Time.deltaTime);
        transform.up = Vector3.up;
    }
}
