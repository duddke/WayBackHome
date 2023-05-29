using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimMove : MonoBehaviour
{
    float speed = 1.5f;
    Vector3 dir;
    Transform Str1;
    Transform Str2;
    Transform Str3;
    Transform Str4;
    Transform Str5;
    bool move2 = false;
    bool move3 = false;
    bool move4 = false;
    bool move5 = false;

    // Start is called before the first frame update

    void Awake()
    {

        StartCoroutine(S1());
        
    }

    // Update is called once per frame
    void Update()
    {
        Str1 = GameObject.Find("S1").transform;
        Str2 = GameObject.Find("S2").transform;
        Str3 = GameObject.Find("S3").transform;
        Str4 = GameObject.Find("S4").transform;
        Str5 = GameObject.Find("S5").transform;
        if (!move2)//1
        {
        dir = Str1.position - transform.position;

        }
        else//2
        {
            dir = Str2.position - transform.position;

        }
        if (move3)//3
        {
            dir = Str3.position - transform.position;

        }
        if(move4) //4
        {
            dir = Str4.position - transform.position;
        }
        if (move5) //5
        {
            dir = Str5.position - transform.position;
        }

        transform.position += dir * speed * Time.deltaTime;




    }

    IEnumerator S1()
    {
        Str1 = GameObject.Find("S1").transform;
        Str2 = GameObject.Find("CM vcam1").transform; 
        dir = Str1.position - transform.position;

            transform.position += dir * speed * Time.deltaTime;
            yield return new WaitForSeconds(2f);
        

    }

    /*if (transform.position.x == Str1.position.x && transform.position. == Str1.position.z)
    {
        print("1111111");
        transform.rotation = Quaternion.Euler(0, 90, 0) * transform.rotation;
    }
        yield return null;*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("S1"))
        {
           
            Quaternion ss = Quaternion.Euler(0, -90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation,ss,0.8f) * transform.rotation;
            move2 = true;
        }
        if (other.gameObject.name.Contains("S2"))
        {
            move3 = true;
        }
        if (other.gameObject.name.Contains("S3"))
        {
            move4 = true;
        }
        if (other.gameObject.name.Contains("S4"))
        {
            move5 = true;
        }

    }

    
}
