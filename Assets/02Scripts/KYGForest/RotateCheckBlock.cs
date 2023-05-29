using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCheckBlock : MonoBehaviour
{
    RotateBlock rtb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rtb = GetComponentInParent<RotateBlock>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        rtb.isChecked = true;
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        rtb.isChecked = false;
    }
}
