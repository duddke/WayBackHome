using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//위 아래로 움직이는 블록
//최초 위치를 기준으로 위로 일정범위, 아래로 일정범위 이동하고 싶다
//필요 속성:속도, 범위, 최초 위치


public class UpDownBlock : MonoBehaviour
{
    public float speed = 3;
    public float roundRange = 5;
    bool dirUp = true;
    
    Vector3 originPosition;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(dirUp == true)
        {
            goUp();
            if (transform.position.y >= originPosition.y + roundRange)
            {
                dirUp = false;
            }
        }
        else
        {
            goDown();         
            if(transform.position.y<= originPosition.y)
            {
                dirUp = true;
            }
        }
    }

    private void goUp()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
    private void goDown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

}
