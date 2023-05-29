using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EsclatorPlatform : PlatForms
{
    public TextMeshProUGUI text;
    public GameObject cloudDirRight;
    public GameObject cloudDirLeft;


    public Vector3 dir;
    public float speed = 7f;
    CharacterController cc;
    public GameObject player;
    public bool IsonPlat;
    int ranValue;

    void Start()
    {
        player = GameObject.Find("Player");
        cc = player.GetComponent<CharacterController>();
        ranValue = UnityEngine.Random.Range(0, 10);
        if (ranValue < 5)
        {
            dir = Vector3.right;
            //text.text = ">>>";
            cloudDirRight.SetActive(true);

        }
        else
        {
            dir = Vector3.left;
            //text.text = "<<<";
            cloudDirLeft.SetActive(true);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Esclating();
    }

    private void Esclating()
    {
        if (IsonPlat)
        {
            cc.Move(dir * speed * Time.deltaTime);
        }
    }
}
