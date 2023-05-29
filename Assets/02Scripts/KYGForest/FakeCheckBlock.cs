using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCheckBlock : MonoBehaviour
{
    FakeBlock fb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        fb = GetComponentInParent<FakeBlock>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        fb.isChecked = true;
        audioSource.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        fb.isChecked = false;
    }
}
