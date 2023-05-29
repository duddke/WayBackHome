using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public enum State
    {
        Idle,   
        Chase,
        Attack,
        Return
    }

    
   public State state;
    public GameObject player;

    NavMeshAgent nm;
   public int randomValue;
    float curTime;
    void Start()
    {
        state = State.Idle;
        nm = GetComponent<NavMeshAgent>();
         player = GameObject.Find("Player");
        nm.speed = 10f;

        randomValue =  UnityEngine.Random.Range(0, 30);
        nm.destination = Waypoints.instance.waypoints[randomValue].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (state==State.Idle)
        {
            UPdateIdle();
        }
        if (state == State.Chase)
        {
            UPdateChase();

        }
        if (state == State.Attack)
        {
            UPdateAttack();

        }
        if (state == State.Return)
        {
            UPdateReturn();

        }
    }

    float detectRadius = 7f;
    private void UPdateIdle()
    {
       
        Collider[] cols = Physics.OverlapSphere(this.transform.position, detectRadius,1 << LayerMask.NameToLayer("Player"));

        if (cols.Length>0)
        {
           
            nm.destination = cols[0].gameObject.transform.position;
            state = State.Chase;
        }
        else
        {
            nm.destination = Waypoints.instance.waypoints[randomValue].transform.position;

        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Way"))
        {
            
            int temp = randomValue;
            randomValue =  UnityEngine.Random.Range(0, 30);

            if (randomValue== temp)
            {
                randomValue++;
                if (randomValue > 30)
                {
                    randomValue = 0;
                }
            }
            
            nm.destination = Waypoints.instance.waypoints[randomValue].transform.position;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Way"))
        {
            curTime += Time.deltaTime;
            if (curTime > 2f)
            {
                randomValue = UnityEngine.Random.Range(0, 30);
                curTime = 0;
            }
        }
    }
    public float attackDistance = 2f;
    float dist;
    private void UPdateChase()
    {
       

        Collider[] cols = Physics.OverlapSphere(this.transform.position, detectRadius, 1 << LayerMask.NameToLayer("Player"));
        if (cols.Length>0)
        {

        nm.destination = cols[0].gameObject.transform.position;
        }

        if (cols.Length < 1)
        {
           
            nm.destination = Waypoints.instance.waypoints[randomValue].transform.position;

            state = State.Idle;
        }
         dist = Vector3.Distance(transform.position , player.transform.position);
        if (dist <= attackDistance && PlayerMove.instance.hide==false)
        {
            state = State.Attack;
        }
       
    }
    
    private void UPdateAttack()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > attackDistance)
        {
            state = State.Chase;
        }
        if (PlayerMove.instance.hide == false)
        {
            state = State.Chase;
        }
    }
    private void UPdateReturn()
    {
      
    }



}
