using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YA_SlimeMesh : MonoBehaviour
{
    
    public GameObject slimeLv1;
    public GameObject slimeLv2;
    public GameObject slimeLv3;
    public GameObject slimeLv4;
    
    private bool state1;
    private bool state2;
    private bool state3;
    private bool state4;
    // Start is called before the first frame update
    void Start()
    {
        
        state1 = false;
        state2 = false;
        state3 = false;
        state4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //스타가 0일때
        if (YA_PlayerStar.instance.starScore == 0)
        {
            //스테이트가 펄스(모습이 안 보이면)
            if (!state1)
            {
                //게임옵젝을 활성화한다
                slim1on();
            }
            if (state2)
            {
                slim2off();
            }
            if (state3)
            {
                slim3off();
            }
            if (state4)
            {
                slim4off();
            }
        }
        else if (YA_PlayerStar.instance.starScore == 1)
        {
            if (state1)
            {
                //게임옵젝을 활성화한다
                slim1off();
            }
            if (!state2)
            {
                slim2on();
            }
            if (state3)
            {
                slim3off();
            }
            if (state4)
            {
                slim4off();
            }
        }
        else if (YA_PlayerStar.instance.starScore == 2)
        {
            if (state1)
            {
                //게임옵젝을 활성화한다
                slim1off();
            }
            if (state2)
            {
                slim2off();
            }
            if (!state3)
            {
                slim3on();
            }
            if (state4)
            {
                slim4off();
            }
        }
        else if (YA_PlayerStar.instance.starScore == 3)
        {
            if (state1)
            {
                //게임옵젝을 활성화한다
                slim1off();
            }
            if (state2)
            {
                slim2off();
            }
            if (state3)
            {
                slim3off();
            }
            if (!state4)
            {
                slim4on();
            }
        }



    }


    void slim1on()
    {
        slimeLv1.SetActive(true);
        state1 = true;
        GameObject slime1 = Instantiate(slimeLv1);
        slime1.transform.position = transform.position;
    }
    void slim2on()
    {
        slimeLv2.SetActive(true);
        state2 = true;
        GameObject slime2 = Instantiate(slimeLv2);
        slime2.transform.position = transform.position;
    }
    void slim3on()
    {
        slimeLv3.SetActive(true);
        state3 = true;
        GameObject slime3 = Instantiate(slimeLv3);
        slime3.transform.position = transform.position;
    }
    void slim4on()
    {
        slimeLv4.SetActive(true);
        state4 = true;
        GameObject slime4 = Instantiate(slimeLv4);
        slime4.transform.position = transform.position;
    }


    void slim1off()
    {
        slimeLv1.SetActive(false);
        state1 = false;
    }
    void slim2off()
    {
        slimeLv2.SetActive(false);
        state2 = false;
    }
    void slim3off()
    {
        slimeLv3.SetActive(false);
        state3 = false;
    }
    void slim4off()
    {
        slimeLv4.SetActive(false);
        state4 = false;
    }

}
