using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class StartUIColor : MonoBehaviour
{
    public GameObject startText;
   public Renderer[] rdr;
    public Material[] mat;
    // Start is called before the first frame update
    private void Awake()
    {
         //rdr = startText.gameObject.GetComponentsInChildren<Renderer>();
       
    }
    void Start()
    {
        rdr = startText.gameObject.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rdr.Length; i++)
        {
            mat[i] = rdr[i].material;
        }
    }
    private void Update()
    {
       
    }

    // Update is called once per frame

    public void ChangeColor()
    {
        for (int i = 0; i < rdr.Length; i++)
        {
            
            print(3);
            rdr[i].material .color = Color.Lerp(mat[i].color, new Color(149, 224, 114, 235), 1 * Time.deltaTime);
        }
    }
}
