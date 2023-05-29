using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBCheckBlock : MonoBehaviour
{
    MovingBlock mb;
    CharacterController cc;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
         mb = GetComponentInParent<MovingBlock>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //print("1");
        //cc = other.GetCd omponent<CharacterController>();
        mb.playerChecked = true;
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();

    }
    private void OnTriggerExit(Collider other)
    {
        mb.playerChecked = false;
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    //���� MovingBlock�� �̵������� �������̶��
    //    if(other.name == "Player")
    //    {
    //        //print("123");

    //        if (mb.dirRight)
    //        {
    //            cc.Move(Vector3.right * mb.speed/2 * Time.deltaTime);
    //        }
    //        else
    //        {
    //            //   print("false");
    //            cc.Move(Vector3.left * mb.speed/2 * Time.deltaTime);
    //        }
    //        //�浹�� ��ü�� ���� �������� �̵���Ű�� �ʹ�.
    //    }

    //}
}
