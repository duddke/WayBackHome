using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public bool WBChecked = false;
    public float windSpeed = 5;
    public float windHeight = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WBChecked == true)
        {
            //print("step2");
           
            
        }
        if (WBChecked == false)
        {
            //print("step2");
            PlayerMove.instance.WindOut();

        }
    }

}
