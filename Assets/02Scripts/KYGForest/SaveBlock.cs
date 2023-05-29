using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBlock : MonoBehaviour
{
    public bool SaveChecked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveChecked == true)
        {
           
            PlayerMove.instance.respawnPosition = transform.position + Vector3.up * 5;
        }
    }
}
