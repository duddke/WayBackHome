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

            //어떤 버튼이든 가져다대면
            if (button != null)
            {



                //거기서 누르면 이벤트발생
                if (Input.GetButtonUp("Fire1"))
                {

                    button.onClick.Invoke();
                }


                // 버튼이 켜져있고 ,스타트 버튼이면
                if (hitinfo.transform.gameObject.GetComponent<UIbutton>().count >= 5 && hitinfo.transform.gameObject.name == "Start")
                {
                    if (uion == false)
                    {
                        uiSound.Play();
                        uion = true;
                    }

                    // start 텍스트들의 렌더러 가져와서 컬러바꾼다
                    for (int i = 0; i < rdr.Length; i++)
                    {
                        mat = rdr[i].material;
                        //mat.color = Color.Lerp(mat.color, targetColor, 5f * Time.deltaTime);
                        //mat.SetColor("_EmissionColor", Color.Lerp(startoriginColor, targetColor, sp));
                        mat.SetColor("_EmissionColor", targetColor);

                    }
                    //sp += Time.deltaTime;

                    //버튼은대고있느디 그게 quit버튼이라면 ? 하얀색으로바꿔줌

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
                // Quit버튼이면 색바꾸자
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
                // Start 버튼 대고있어도 quit버튼 흰색으로
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
            //버튼안대고있으면 두개다 흰색으로 
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





