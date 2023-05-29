using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBlock : MonoBehaviour
{
    public bool isChecked = false;
    PlayerMove player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMove.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChecked == true)
        {
            player.cc.enabled = false;
            player.transform.position = player.respawnPosition;
            player.cc.enabled = true;
            isChecked = false;
        }
    }
}
