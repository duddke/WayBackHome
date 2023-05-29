using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Panel : MonoBehaviour
{
    GameObject SplashObj;               //�ǳڿ�����Ʈ
    Image image;                            //�ǳ� �̹���
    private bool checkbool = false;     //���� ���� ���� ����
    //����� �ó׸�ƽ ī�޶�
    public GameObject CiCamera;




    void Awake()
    {
        SplashObj = this.gameObject;                         //��ũ��Ʈ ������ ������Ʈ
        image = SplashObj.GetComponent<Image>();    //�ǳڿ�����Ʈ�� �̹��� ����
        CiCamera = GameObject.Find("Main Camera");
        CiCamera.SetActive(false);
    }



    void Update()
    {
        StartCoroutine("MainSplash");                        //�ڷ�ƾ    //�ǳ� ���� ����
        if (checkbool)                                            //���� checkbool �� ���̸�
        {
            gameObject.SetActive(false);                        //�ǳ� �ı�, ����
            CiCamera.SetActive(true);
        }
    }



    IEnumerator MainSplash()
    {
        Color color = image.color;                            //color �� �ǳ� �̹��� ����
        for (int i = 100; i >= 0; i--)                            //for�� 100�� �ݺ� 0���� ���� �� ����
        {
            color.a -= Time.deltaTime * 0.01f;               //�̹��� ���� ���� Ÿ�� ��Ÿ �� * 0.01
            image.color = color;                                //�ǳ� �̹��� �÷��� �ٲ� ���İ� ����
            if (image.color.a <= 0)                        //���� �ǳ� �̹��� ���� ���� 0���� ������
            {
               checkbool = true;                              //checkbool �� 
            }
        }
        yield return null;                                        //�ڷ�ƾ ����

    }
}
