using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class UIcolor : MonoBehaviour
{
    MeshRenderer[] rdr;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        rdr = GetComponentsInChildren<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rdr.Length; i++)
        {
            mat = rdr[i].material;
        mat.color= Color.Lerp(mat.color, Color.black, 0.1f * Time.deltaTime);
        }
        //mat.color = Color.Lerp(mat.color, Color.black, 0.1f * Time.deltaTime);
    }
}
