using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�� �Ʒ��� �����̴� ���
//���� ��ġ�� �������� ���� ��������, �Ʒ��� �������� �̵��ϰ� �ʹ�
//�ʿ� �Ӽ�:�ӵ�, ����, ���� ��ġ


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
