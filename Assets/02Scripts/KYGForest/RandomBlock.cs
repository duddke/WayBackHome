using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���� Ȯ���� EventBlock��ġ�� �̵�, ���� Ȯ���� ������ ��ġ�� �̵�
//�÷��̾ �����Ǹ�

public class RandomBlock : MonoBehaviour
{
    public bool isChecked = false;
    public float eventValue = 3;
    int randomValue;
    EventBlock eb;
    // Start is called before the first frame update
    void Start()
    {
        eb = GetComponentInChildren<EventBlock>();
        
    }

    // Update is called once per frame
    void Update() 
    {
        
        if (isChecked == true && Input.GetKeyDown(KeyCode.W))
        {
            randomValue = UnityEngine.Random.Range(0, 10);
            RandomMove();
            isChecked = false;
        }
    }

    private void RandomMove()
    {
        if(randomValue <= eventValue)
        {
            PlayerMove.instance.cc.enabled = false;
            PlayerMove.instance.transform.position = eb.transform.position + Vector3.up * 3;
            PlayerMove.instance.cc.enabled = true;
        }
        else
        {
            PlayerMove.instance.cc.enabled = false;
            PlayerMove.instance.transform.position = PlayerMove.instance.respawnPosition + Vector3.up * 3;
            PlayerMove.instance.cc.enabled = true;
        }
    }
}
