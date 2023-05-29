using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinAnim : MonoBehaviour
{
    [Range(0, 2)]
    public float dollstartoffset;
    private Animator anim;
    AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();


        anim.Play("PumkinIdle", 0, dollstartoffset);
        jumpSound= GetComponent<AudioSource>();

    }

    void OnStartSound()
    {
        jumpSound.Play();
    }

    // Update is called once per frame

}