using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIbutton : MonoBehaviour
{
    public int count;
    StartUIColor uicolor;
    bool iscoloractive;
    public Animator animator;
    public Animator dooranimator;

    AudioSource click;
     

    void Start()
    {
        count = 0;
        click = GetComponent<AudioSource>();
        //uicolor = GameObject.Find("Main Camera").gameObject.GetComponent<StartUIColor>();
    }

    // Update is called once per frame
  
    private void OnTriggerEnter(Collider other)
    {
        count++;

        ////������������������  ���������� => ��ư ������ ���������� �� ???
        //if (count>=5)
        //{
        //    Button button =GetComponent<Button>();
        //    button.enabled = true;
        //    //uicolor.enabled = true;
        //}

    }
    public void OnstartMainScene()
    {
        //if (count>=5)
        //{

        //SceneManager.LoadScene("MainScene");
        //}
    }
    public void OnQuit()
    {
        if (count >=4)
        {
            
            click.Play();

            Application.Quit();
        }
    }
    public void AnimStart()
    {
        if (count >= 5)
        {
            click.Play();
            animator.enabled = true;
            dooranimator.enabled = true;
        }
    }
}
