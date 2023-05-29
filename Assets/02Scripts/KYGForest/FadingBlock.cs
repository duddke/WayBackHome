using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingBlock : MonoBehaviour
{
    Material mat;
    Color tempColor;
    float progress = 0;
    public bool isVisible = true;
    Collider coli;
    public float disappearTime = 3f;
    public MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        coli = GetComponent<Collider>();
        mat = renderer.material;
        tempColor = mat.color;
        tempColor.a = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        mat.color = tempColor;
        if (isVisible)
        {
            FadeOut();
        }
        else
        {
            FadeIn();
        }
    }

    private void FadeOut()
    {
        if (progress < 1)
        {
            tempColor.a = Mathf.Lerp(1, 0, progress);
            progress += Time.deltaTime/ disappearTime;
            if(mat.color.a <= 0.2f)
            {
                coli.enabled = false;
                isVisible = false;
                progress = 0;
            }
           // mat.color = tempColor;
        }

    }

    private void FadeIn()
    {
        if (progress < 1)
        {
            
            tempColor.a = Mathf.Lerp(0, 1, progress);
            progress += Time.deltaTime/ 3.0f;
            if (mat.color.a >= 0.9f)
            {
                isVisible = true;
                progress = 0;
            }
            if(mat.color.a>= 0.2f)
            {
                coli.enabled = true; 
            }
            
            // mat.color = tempColor;
        }
    }
}
