using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownCheckBlock : MonoBehaviour
{
    UpDownBlock udb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        udb = GetComponentInParent<UpDownBlock>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }
}
