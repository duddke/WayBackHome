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
            //// Slippery platform Ÿ�� cc isground �ȸ��� -> �߷°� �������� --> �̷��� �ش���ǿ��� ��������
            //pm.cc.enabled = false;
            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");
            //Vector3 dirr = new Vector3(h, 0, v);
            //dirr.Normalize();
            //player.transform.position += dirr * pm.speed * Time.deltaTime;

              playertransform = player.transform.localPosition;
            //�÷��̾�����϶�
            if (playertransform.x < transform.localPosition.x)
            {
                PlayerX = transform.localPosition.x - playertransform.x;
                 dir = -Vector3.right * PlayerX;
                //�ٵ� ���� z Rotaton���� ������� (������ �ö���ִ»���)
                if (PlatRotZ<0)
                {
                     dir = Vector3.right * PlayerX;
                }
                dir.Normalize();
                cc.Move(dir * SliperSpeed * Time.deltaTime);
            }
            //�������϶�
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
            // �����϶�
            if (playertransform.z < transform.localPosition.z)
            {
                PlayerZ = transform.localPosition.z- playertransform.z;
                 dir = -Vector3.forward * PlayerZ;
                //�ٵ� x Rotatation�� ������ (������ �ö���ִ»���)
                if (PlatRotX > 0)
                {
                    dir = Vector3.forward * PlayerZ;
                }
                dir.Normalize();

                cc.Move(dir * SliperSpeed * Time.deltaTime);

            }
            // �����϶�
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
            //���� ������� this.������Ʈ�� vector3(x,0,z)�� �Է¹ް�
             playertransform = player.transform.position;
            //������Ʈ�� ���������� ��������
            if (playertransform.x < transform.position.x)
            {

                // �÷��̾��� X���� �����ϴ� ��ŭ rotation  z ���� ����
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
