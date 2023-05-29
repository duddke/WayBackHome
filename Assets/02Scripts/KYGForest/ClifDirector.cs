using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class ClifDirector : MonoBehaviour
{
    public PlayableDirector director;
    
    // Start is called before the first frame update
    void Start()
    {
        director.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CamManager.Instaced.spCam == true)
        {
            director.enabled = true;
            if(CamManager.Instaced.ClifCamera.activeSelf == true)
            {
                PlayerMove.instance.enabled = false;
            }
            else
            {
                PlayerMove.instance.enabled = true;
            }
            
        }
        
    }
}
