using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            PlayerMove.instance.cc.enabled = false;
            other.transform.position = PlayerMove.instance.respawnPosition;
            PlayerMove.instance.cc.enabled = true;
            PlayerSoundManager.Instance.ReSpawnSoundOn();

        }
        
    }
}
