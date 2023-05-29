using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime1 : MonoBehaviour
{
    public GameObject sli1;
    public GameObject sli2;
    public GameObject sli3;
    public GameObject sli4;
    /*public GameObject sli3;
    public GameObject sli4;*/
    private bool state;
    // Start is called before the first frame update
    void Start()
    {
        sli1.gameObject.SetActive(true);
        sli2.gameObject.SetActive(false);
        sli3.gameObject.SetActive(false);
        sli4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (YA_PlayerStar.instance.starScore == YA_PlayerStar.instance.starScoreOne)
        {
            sli1.gameObject.SetActive(false);
            sli2.gameObject.SetActive(true);
            sli3.gameObject.SetActive(false);
            sli4.gameObject.SetActive(false);

        }
        else if (YA_PlayerStar.instance.starScore == YA_PlayerStar.instance.starScoreTwo)
        {
            sli1.gameObject.SetActive(false);
            sli2.gameObject.SetActive(false);
            sli3.gameObject.SetActive(true);
            sli4.gameObject.SetActive(false);
        }
        else if (YA_PlayerStar.instance.starScore == YA_PlayerStar.instance.starScoreThree)
        {
            sli1.gameObject.SetActive(false);
            sli2.gameObject.SetActive(false);
            sli3.gameObject.SetActive(false);
            sli4.gameObject.SetActive(true);
        }

    }

    /*void slimon()
    {
        gameObject.SetActive(true);
        state = true;

    }
    void slimoff()
    {
        gameObject.SetActive(false);
        state = false;
    }*/

}