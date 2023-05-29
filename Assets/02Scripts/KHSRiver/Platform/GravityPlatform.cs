using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityPlatform : PlatForms
{
    // 플레이어가 밟으면 점점 중력값이 -9.81까지 증가한다
    //필요속성 중력값, 플레이어, 밟았는지불값,
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
        //만약 플레이가 밟고있는 상태라면
        // 아래방향으로 중력이 증가한다 9.81f가 될때까지
        if (IsonPlat)
        {
            gravityRain.SetActive(true);
            //무빙플랫폼 멈춰벌여
            mp.speed = 0;
            if (tempGravity<= gravity)
            {
                tempGravity += gravityAddSpeed * Time.deltaTime;
            }
        }
    }
}
