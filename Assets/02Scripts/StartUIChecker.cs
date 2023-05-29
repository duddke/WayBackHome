using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StartUIChecker : MonoBehaviour
{
    public GameObject startText;
    public GameObject QuitText;

    MeshRenderer[] rdr;
    MeshRenderer[] rdr2;

    Material mat;
    StartUIColor uicolor;
    //Color targetColor = new Color(0.9183506f, 0.9333333f, 0.04705882f, 1);
    Color targetColor = new Color(0.8679246f, 0.3410289f, 0.06959774f, 1) * 5;
    Color startoriginColor;
    Color wayoriginColor;

    bool uion;
    AudioSource uiSound;

    void Start()
    {
        uicolor = GameObject.Find("Main Camera").gameObject.GetComponent<StartUIColor>();
        uiSound = GetComponent<AudioSource>();

        rdr = startText.GetComponentsInChildren<MeshRenderer>();
        rdr2 = QuitText.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < rdr.Length; i++)
        {
            mat = rdr[i].material;
            //mat.EnableKeyword("_EMISSION");
            startoriginColor = mat.GetColor("_EmissionColor");
        }
        for (int i = 0; i < rdr2.Length; i++)
        {
            mat = rdr2[i].material;
            //mat.EnableKeyword("_EMISSION");
            wayoriginColor = mat.GetColor("_EmissionColor");

        }
    }

    // Update is called once per frame
    void Update()
    {
        UIchecker();

    }

    float sp = 0;
    private void UIchecker()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;
        if (Physics.Raycast(camRay, out hitinfo))
        {
            Button button = hitinfo.transform.GetComponent<Button>();

            //� ��ư�̵� �����ٴ��
            if (button != null)
            {



                //�ű⼭ ������ �̺�Ʈ�߻�
                if (Input.GetButtonUp("Fire1"))
                {

                    button.onClick.Invoke();
                }


                // ��ư�� �����ְ� ,��ŸƮ ��ư�̸�
                if (hitinfo.transform.gameObject.GetComponent<UIbutton>().count >= 5 && hitinfo.transform.gameObject.name == "Start")
                {
                    if (uion == false)
                    {
                        uiSound.Play();
                        uion = true;
                    }

                    // start �ؽ�Ʈ���� ������ �����ͼ� �÷��ٲ۴�
                    for (int i = 0; i < rdr.Length; i++)
                    {
                        mat = rdr[i].material;
                        //mat.color = Color.Lerp(mat.color, targetColor, 5f * Time.deltaTime);
                        //mat.SetColor("_EmissionColor", Color.Lerp(startoriginColor, targetColor, sp));
                        mat.SetColor("_EmissionColor", targetColor);

                    }
                    //sp += Time.deltaTime;

                    //��ư������ִ��� �װ� quit��ư�̶�� ? �Ͼ�����ιٲ���

                }
                else if (hitinfo.transform.gameObject.name == "Quit")
                {


                    for (int i = 0; i < rdr.Length; i++)
                    {
                        mat = rdr[i].material;
                        //mat.color = Color.Lerp(mat.color, startoriginColor, 5f * Time.deltaTime);
                        //mat.SetColor("_EmissionColor", Color.Lerp(mat.color, startoriginColor, 5 * Time.deltaTime));
                        mat.SetColor("_EmissionColor", startoriginColor);


                    }

                }
                // Quit��ư�̸� ���ٲ���
                if (hitinfo.transform.gameObject.GetComponent<UIbutton>().count >= 4 && hitinfo.transform.gameObject.name == "Quit")
                {
                    if (uion == false)
                    {
                        uiSound.Play();
                        uion = true;
                    }
                    for (int i = 0; i < rdr2.Length; i++)
                    {
                        mat = rdr2[i].material;
                        //mat.color = Color.Lerp(mat.color, targetColor, 5f * Time.deltaTime);
                        //mat.SetColor("_EmissionColor", Color.Lerp(mat.color, targetColor, 5 * Time.deltaTime));
                        mat.SetColor("_EmissionColor", targetColor);

                    }

                }
                // Start ��ư ����־ quit��ư �������
                else if (hitinfo.transform.gameObject.name == "Start")
                {

                    for (int i = 0; i < rdr2.Length; i++)
                    {
                        mat = rdr2[i].material;
                        //mat.color = Color.Lerp(mat.color, startoriginColor, 5f * Time.deltaTime);
                        //mat.SetColor("_EmissionColor", Color.Lerp(mat.color, startoriginColor, 5 * Time.deltaTime));
                        mat.SetColor("_EmissionColor", startoriginColor);
                    }

                }
            }
            //��ư�ȴ�������� �ΰ��� ������� 
            else if (!button)
            {
                uion = false;

                for (int i = 0; i < rdr.Length; i++)
                {
                    mat = rdr[i].material;
                    //mat.color = Color.Lerp(mat.color, startoriginColor, 5f * Time.deltaTime);
                    mat.SetColor("_EmissionColor", startoriginColor);// Color.Lerp(mat.color, startoriginColor, 5 * Time.deltaTime));

                }

                for (int i = 0; i < rdr2.Length; i++)
                {
                    mat = rdr2[i].material;
                    //mat.color = Color.Lerp(mat.color, wayoriginColor, 5f * Time.deltaTime);
                    mat.SetColor("_EmissionColor", startoriginColor);// Color.Lerp(mat.color, startoriginColor, 5 * Time.deltaTime));

                }
                //sp = 0;



            }
        }
    }
}





