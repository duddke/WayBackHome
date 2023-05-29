using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    float rotspeed = 150f;
    float mx = 0;
    float my = 0;
    float x;
    float y;
    public GameObject player;
    float smoothSpeed = 3;
    Vector3 reverseDistance;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;
        //camPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //마우스의 입력에 따라 화면이 돌아간다
        if (!CamManager.Instaced.spCam)
        {

            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");
            mx += x * rotspeed * Time.deltaTime;
            my += y * rotspeed * Time.deltaTime;
            my = Mathf.Clamp(my, -50f, 15f);
            transform.rotation = Quaternion.Euler(-my, mx, 0);

            ObstacleCheck();


            //camPosition.y = player.transform.position.y + offsety;
            //camPosition.y = Mathf.Clamp(camPosition.y, -90f, 90);
            if(!PlayerMove.instance.isJumping) reverseDistance = new Vector3(0.0f, -1f, 6.5f);
            else reverseDistance = new Vector3(0.0f, -1f, 10.5f);
            // 플레이어를 카메라가 따라간다
            transform.position = Vector3.Lerp(transform.position, player.transform.position - (transform.rotation * reverseDistance), Time.deltaTime * smoothSpeed);
            //transform.position = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * smoothSpeed);
            //transform.position = player.transform.position - transform.rotation * reverseDistance;
            // Z

        }
        //else
        //{

        //    transform.position = Vector3.Lerp(transform.position, GameObject.Find("EventCamera").transform.position, Time.deltaTime);
        //    //transform.position += dir * speed * Time.deltaTime;
        //}

    }

    private void ObstacleCheck()
    {
       
        Ray ray = new Ray(player.transform.position, transform.position - player.transform.position);
        RaycastHit hitinfo;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (Physics.Raycast(ray, out hitinfo, distance, 1<< LayerMask.NameToLayer("BackGround")))
            {
            transform.position = hitinfo.point;
          

        }

    }

    //private void LateUpdate()
    //{
    //}
    public IEnumerator Cam(float a)
    {
        yield return new WaitForSeconds(a);  // yield return 을 통해 시간지연  
    }
}
