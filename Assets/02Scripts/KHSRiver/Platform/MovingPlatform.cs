using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovingPlatform : PlatForms
{
    //�̵��ϴ� ���� - ���ʿ��� ���ʹ������� ���Ӿ��� ������(������ �������� ������ �԰�����)
    public TextMeshProUGUI text;

    public Vector3 dir;
    public float speed = 5f;
    public GameObject player;
    CharacterController cc;
    public bool IsonPlat;

    //������� ID
    public int id =0;
    public PlatFactory platFactory;
    //PlayerMove pm;
    // Start is called before the first frame update
    void Start()
    {
        
        //text.text = "Normal";

        player = GameObject.Find("Player");
        //pm = player.GetComponent<PlayerMove>();
        cc = player.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        transform.position += dir * speed * Time.deltaTime;
        if (IsonPlat)
        {
            cc.Move(dir * speed * Time.deltaTime);
           
        }

    }
}
