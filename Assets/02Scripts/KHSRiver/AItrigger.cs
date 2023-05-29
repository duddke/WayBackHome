using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AItrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject AI;
    public bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            isTriggered = true;
        }
    }
    private void Update()
    {
        if (isTriggered == true)
        {
            player.GetComponent<KHSmovingCopy>().replaying = true;
        }
    }

}
