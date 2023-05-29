using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KHSmovingCopy : MonoBehaviour
{
    //�����Ǵ��� ����Ʈ�ϳ������
    // �������ǹް�
    //  AI�����ǹް�
    // �� ���ڵ� ����

    public List<Vector3> positions;
    public GameObject player;
    public GameObject AI;
    public bool replaying;
    void Start()
    {
        //����Ʈ  �ʱ�ȭ
        positions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        // �ҷ��ڵ��϶���
        if (replaying)
        {
            Replaying();
        }
        else
        {
            Record();
        }
    }


    private void Record()
    {
        positions.Add( player.transform.position);
    }
    private void Replaying()
    {
        
            AI.transform.position = positions[0];
        positions.RemoveAt(0);
        positions.Insert(positions.Count, player.transform.position);


    }
}
