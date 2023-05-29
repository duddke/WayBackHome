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
        
        //Ư�� ī�޶� ��尡 �� �Ǹ�(����)
        if(spCam)
        {
            //����ī�޶� A���� B�� ���� (B���� ��ǥ(7,4,20))
            //����ī�޶� Projection�� ����׷��� ī�޶� Ų��
            //StartCoroutine(Cam(5f));
            EventCamera.GetComponent<Camera>().enabled = true;
            MainCamera.GetComponent<Camera>().enabled = false;
            //����׷���

            //����ī�޶�� �÷��̾�� ���� �Ÿ��� �ΰ� ���� �����δ�

            // Quaternion(0, -90, 0);
            //����ī�޶�� (��ǥ)C~D������ �̵��� �� �ִ� c~d(7,4,64)(7,4,145)
            /*��loat z = transform.position.z;
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
