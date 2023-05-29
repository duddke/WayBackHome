using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingUIManager : MonoBehaviour
{
    GameObject Restart;
    GameObject Quit;
    GameObject Bg;
    GameObject WA;
    GameObject MA;
    
    // Start is called before the first frame update
    void Awake()
    {
        Bg = GameObject.Find("Bg");
        Restart = GameObject.Find("RESTART");
        Quit = GameObject.Find("QUIT");
        Restart.SetActive(false);
        Quit.SetActive(false);
        Bg.SetActive(false);
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        WA = GameObject.Find("Welcome Back Home");
        MA = GameObject.Find("Mate");
        Invoke("UIset", 15f);

    }

    void UIset()
    {
        Restart.SetActive(true);
        Quit.SetActive(true);
        Bg.SetActive(true);
        if (WA && MA)
        {
            WA.SetActive(false);
            MA.SetActive(false);
        }
    }
}
