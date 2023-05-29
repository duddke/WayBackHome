using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public static CamManager Instaced;


    public  bool spCam = false;

    public GameObject EventCamera;
    public GameObject MainCamera;
    public GameObject ClifCamera;
    public GameObject ForestCamera;

    private void Awake()
    {
        Instaced = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventCamera.GetComponent<Camera>().enabled = false;
        MainCamera.GetComponent<Camera>().enabled = true;
    }

    public void spCamTranOn()
    {
        spCam = true;
    }
    public void spCamTranOff()
    {
        spCam = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        //특수 카메라 모드가 온 되면(이프)
        if(spCam)
        {
            //메인카메라가 A에서 B로 간다 (B지점 좌표(7,4,20))
            //메인카메라 Projection을 오토그래픽 카메라를 킨다
            //StartCoroutine(Cam(5f));
            EventCamera.GetComponent<Camera>().enabled = true;
            MainCamera.GetComponent<Camera>().enabled = false;
            //오토그래픽

            //메인카메라는 플레이어와 일정 거리를 두고 따라 움직인다

            // Quaternion(0, -90, 0);
            //메인카메라는 (좌표)C~D까지만 이동할 수 있다 c~d(7,4,64)(7,4,145)
            /*ㄹloat z = transform.position.z;
            float mz = Mathf.Clamp(z, 64f, 145f);
            transform.eulerAngles = new Vector3(14, -90f, -0.3f);
            StartCoroutine(Cam());
            transform.position = target.transform.position + new Vector3(7f, 3f, mz);*/
        }
        else if(!spCam)
        {
            EventCamera.GetComponent<Camera>().enabled = false;
            MainCamera.GetComponent<Camera>().enabled = true;
            /*transform.position = target.transform.position+ new Vector3(0,6f,-8f);*/

        }

    }
 




}
