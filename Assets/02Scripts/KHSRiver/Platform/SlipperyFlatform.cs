using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlipperyFlatform : PlatForms
{
    public TextMeshProUGUI text;
    public GameObject player;
    PlayerMove pm;
    CharacterController cc;
    public bool IsonPlat;

    public float PlatRotZ;
   public float PlayerX;
    public float PlatRotX;
   public float PlayerZ;
    Vector3 playertransform;
    Vector3 dir;

    public float RotSpeed = 20f;
    public float SliperSpeed = 1f;
    void Start()
    {
        player = GameObject.Find("Player");
        pm = player.GetComponent<PlayerMove>();
        cc = player.GetComponent<CharacterController>();
        //text.text = "slipery";



    }

    
    void FixedUpdate()
    {
        Rottating();
        Sliperring();

    }

    private void Sliperring()
    {
        if (IsonPlat)
        {
            //// Slippery platform 타면 cc isground 안먹음 -> 중력값 누적방지 --> 이러면 해당발판에서 점프못함
            //pm.cc.enabled = false;
            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");
            //Vector3 dirr = new Vector3(h, 0, v);
            //dirr.Normalize();
            //player.transform.position += dirr * pm.speed * Time.deltaTime;

              playertransform = player.transform.localPosition;
            //플레이어가왼쪽일때
            if (playertransform.x < transform.localPosition.x)
            {
                PlayerX = transform.localPosition.x - playertransform.x;
                 dir = -Vector3.right * PlayerX;
                //근데 만약 z Rotaton값이 음수라면 (왼쪽이 올라와있는상태)
                if (PlatRotZ<0)
                {
                     dir = Vector3.right * PlayerX;
                }
                dir.Normalize();
                cc.Move(dir * SliperSpeed * Time.deltaTime);
            }
            //오른쪽일때
            if (playertransform.x > transform.localPosition.x)
            {
                PlayerX = transform.localPosition.x - playertransform.x;
                 dir = -Vector3.right * PlayerX;

                if (PlatRotZ > 0)
                {
                    dir = Vector3.right * PlayerX;

                }
                dir.Normalize();

                cc.Move(dir * SliperSpeed * Time.deltaTime);


            }
            // 뒤쪽일때
            if (playertransform.z < transform.localPosition.z)
            {
                PlayerZ = transform.localPosition.z- playertransform.z;
                 dir = -Vector3.forward * PlayerZ;
                //근데 x Rotatation이 양수라면 (뒤쪽이 올라와있는상태)
                if (PlatRotX > 0)
                {
                    dir = Vector3.forward * PlayerZ;
                }
                dir.Normalize();

                cc.Move(dir * SliperSpeed * Time.deltaTime);

            }
            // 앞쪽일때
            if (playertransform.z > transform.localPosition.z)
            {
                PlayerZ = transform.localPosition.z- playertransform.z;
                 dir = -Vector3.forward * PlayerZ;

                if (PlatRotX < 0)
                {
                    dir = Vector3.forward * PlayerZ;
                }
                dir.Normalize();

                cc.Move(dir * SliperSpeed * Time.deltaTime);


            }

        }

    }

    private void Rottating()
    {
        if (IsonPlat)
        {
            //만약 밟았으면 this.오브젝트가 vector3(x,0,z)를 입력받고
             playertransform = player.transform.position;
            //오브젝트의 로컬포지션 기준으로
            if (playertransform.x < transform.position.x)
            {

                // 플레이어의 X값이 감소하는 만큼 rotation  z 값은 증가
                //PlatRotZ = transform.eulerAngles.z;
                PlayerX = transform.position.x -playertransform.x ;

                
                //print(PlayerX);
                PlatRotZ += PlayerX * RotSpeed * Time.deltaTime;
                PlatRotZ = Mathf.Clamp(PlatRotZ, -35, 35);
                

                //Quaternion targetrotation = Quaternion.Euler(new Vector3(0,0, PlatRotZ));
                //transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, Time.deltaTime * 100);

                transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, PlatRotZ);

            }
            if (playertransform.x > transform.position.x)
            {
                //PlatRotZ = transform.eulerAngles.z;

                PlayerX = transform.position.x - playertransform.x;
              


                PlatRotZ += PlayerX * RotSpeed * Time.deltaTime;
                PlatRotZ = Mathf.Clamp(PlatRotZ, -35, 35);


                //Quaternion targetrotation = Mathf.Lerp(transform.eulerAngles.z,)
                transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, PlatRotZ);
            }

            if (playertransform.z < transform.position.z)
            {


                //PlatRotX = transform.eulerAngles.x;
                PlayerZ = transform.position.z- playertransform.z;
                

                PlatRotX += -PlayerZ * RotSpeed * Time.deltaTime;
                PlatRotX = Mathf.Clamp(PlatRotX, -30, 30);





                transform.eulerAngles = new Vector3(PlatRotX, transform.localEulerAngles.y, transform.localEulerAngles.z);

            }
            if (playertransform.z > transform.position.z)
            {
                //PlatRotX = transform.eulerAngles.x;

                PlayerZ = transform.position.z - playertransform.z;

                PlatRotX += -PlayerZ * RotSpeed * Time.deltaTime;
                PlatRotX = Mathf.Clamp(PlatRotX, -30, 30);


                transform.eulerAngles = new Vector3(PlatRotX, transform.localEulerAngles.y, transform.localEulerAngles.z);
            }


        }
    }
}
