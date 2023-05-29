using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovingPlatform : PlatForms
{
    //이동하는 발판 - 한쪽에서 한쪽방향으로 끊임없이 생성됨(랜덤한 간격으로 랜덤한 규격으로)
    public TextMeshProUGUI text;

    public Vector3 dir;
    public float speed = 5f;
    public GameObject player;
    CharacterController cc;
    public bool IsonPlat;

    //생산라인 ID
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
