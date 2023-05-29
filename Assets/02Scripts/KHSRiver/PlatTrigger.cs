using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTrigger : MonoBehaviour
{
    public GameObject player;

    PlayerMove pm;
    CharacterController cc;
     MovingPlatform mp;
    SlipperyFlatform sp;
    GravityPlatform gp;
    EsclatorPlatform ep;
    SwitchdirPlatform sdp;


   

    void Start()
    {
        player = GameObject.Find("Player");
       
        mp = GetComponentInParent<MovingPlatform>();
        sp = GetComponentInParent<SlipperyFlatform>();
        gp = GetComponentInParent<GravityPlatform>();
        ep = GetComponentInParent<EsclatorPlatform>();
        sdp = GetComponentInParent<SwitchdirPlatform>();

    }




    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject ==player)
        {

            mp.IsonPlat = true;
            sp.IsonPlat = true;
            gp.IsonPlat = true;
            ep.IsonPlat = true;
            sdp.IsonPlat = true;


            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject==player)
        {

            mp.IsonPlat = false;
            sp.IsonPlat = false;
            gp.IsonPlat = false;
            ep.IsonPlat = false;
            sdp.IsonPlat = false;


        }
    }
}
