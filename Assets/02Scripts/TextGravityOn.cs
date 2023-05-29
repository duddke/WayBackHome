using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextGravityOn : MonoBehaviour
{
    public Image storyBG;
    Rigidbody rb;
    public bool storyFadein;

    private void Start()
    {
        storyFadein = true;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (storyFadein)
        {

            if (storyBG.color.a <= 0.1f)
            {
                rb.useGravity = true;
                
            }
        }


        //if (storyBG.color == Color.clear)
        //{

        //    storyFadein = false;
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BackGround"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}

