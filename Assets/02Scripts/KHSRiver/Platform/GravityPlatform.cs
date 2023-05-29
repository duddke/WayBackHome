using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityPlatform : PlatForms
{
    // �÷��̾ ������ ���� �߷°��� -9.81���� �����Ѵ�
    //�ʿ�Ӽ� �߷°�, �÷��̾�, ��Ҵ����Ұ�,
    public TextMeshProUGUI text;

    public bool IsonPlat;
    public GameObject player;
    public float tempGravity = 0f;
    public float gravity = 9.81f;
    public float gravityAddSpeed = 200;
    MovingPlatform mp;
    public float mpTempSpeed;
    public GameObject gravityRain;
    Vector3 dir;
    void Start()
    {
        //text.text = "Gravity";


        tempGravity = 0f;
        player = GameObject.Find("Player");
        mp = GetComponent<MovingPlatform>();
        mpTempSpeed = mp.speed;
    }

    // Update is called once per frame
    void Update()
    {
        Falling();
        Graviting();
    }

    private void Graviting()
    {
        dir = Vector3.down;

        transform.position += dir * tempGravity * Time.deltaTime;
    }

    private void Falling()
    {
        //���� �÷��̰� ����ִ� ���¶��
        // �Ʒ��������� �߷��� �����Ѵ� 9.81f�� �ɶ�����
        if (IsonPlat)
        {
            gravityRain.SetActive(true);
            //�����÷��� �������
            mp.speed = 0;
            if (tempGravity<= gravity)
            {
                tempGravity += gravityAddSpeed * Time.deltaTime;
            }
        }
    }
}
