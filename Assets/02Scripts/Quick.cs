using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quick : MonoBehaviour
{
    public GameObject start;
    public GameObject wolf;

    public GameObject waterfall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))   
        {

            transform.position = start.transform.position ;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = wolf.transform.position ;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = waterfall.transform.position ;

        }
    }
}
