using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBCheckBlock : MonoBehaviour
{
    SaveBlock sb;
    bool Cheked;
    bool sound;
    public Light pointLight;
    public MeshRenderer lamp;
    Color targetColor = new Color(1.662745f, 1.011765f, 0.1803922f) * 5f;
    float sp;

    AudioSource saveSound;

    // Start is called before the first frame update
    void Start()
    {
        sb = GetComponentInParent<SaveBlock>();
        saveSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cheked)
        {
            pointLight.intensity = Mathf.Lerp(pointLight.intensity, 2, 5 * Time.deltaTime);
            lamp.material.SetColor("_EmissionColor", Color.Lerp(lamp.material.color, targetColor, sp * 0.8f));
            sp += Time.deltaTime;
           

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!sound)
        {
            saveSound.Play();
            sound = true;
        }
        sp = 0;
        Cheked = true;
        sb.SaveChecked = true;
    }
    private void OnTriggerExit(Collider other)
    {
        sb.SaveChecked = false;
    }
}
