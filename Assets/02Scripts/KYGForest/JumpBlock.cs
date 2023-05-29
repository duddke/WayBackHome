using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour
{
    public bool isChecked = false;
    public float jumpHeight = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isChecked == true)
        {
            PlayerMove.instance.OnJumpingBlock(jumpHeight);
        }
    }
}
