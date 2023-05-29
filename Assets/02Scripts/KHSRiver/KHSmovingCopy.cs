using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KHSmovingCopy : MonoBehaviour
{
    //포지션담을 리스트하나만들고
    // 내포지션받고
    //  AI포지션받고
    // 불 레코딩 선언

    public List<Vector3> positions;
    public GameObject player;
    public GameObject AI;
    public bool replaying;
    void Start()
    {
        //리스트  초기화
        positions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        // 불레코딩일때만
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
