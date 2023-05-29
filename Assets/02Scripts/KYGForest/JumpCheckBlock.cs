using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheckBlock : MonoBehaviour
{
    JumpBlock jb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        jb = GetComponentInParent<JumpBlock>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        jb.isChecked = true;
        PlayerMove.instance.OnJumpBlock = true;
        audioSource.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        jb.isChecked = false;
        PlayerMove.instance.OnJumpBlock = false;
    }
}
