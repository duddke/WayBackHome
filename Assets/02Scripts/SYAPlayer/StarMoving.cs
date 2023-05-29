using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

        float rotSpeed = 1f;
    Vector3 dir;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, rotSpeed, 0) * transform.rotation;
    }
}
