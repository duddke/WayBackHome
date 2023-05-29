using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSwitchIcon : MonoBehaviour
{

    float rotZ;
    public float spd;
    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = new Vector3(1 / transform.root.localScale.x, 1 / transform.root.localScale.y, 1 / transform.root.localScale.z);
    }
    // Update is called once per frame
    void Update()
    {
        rotZ += Time.deltaTime * spd;
        transform.rotation= Quaternion.Euler(0,0, rotZ);
    }
   
}
