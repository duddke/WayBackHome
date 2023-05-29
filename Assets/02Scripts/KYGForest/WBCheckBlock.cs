using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어가 감지되면 플레이어를 위로 올라가게 하고 싶다

//1. 플레이어가 감지되면
//2. 플레이어의 y좌표를 증가시킨다.
public class WBCheckBlock : MonoBehaviour
{
    WindBlock wb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        wb = GetComponentInParent<WindBlock>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        transform.localScale = new Vector3(1, wb.windHeight, 1);
        transform.localPosition = new Vector3(0, wb.windHeight * 0.5f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        wb.WBChecked = true;
        PlayerMove.instance.onWindBlock(wb.windHeight, wb.windSpeed, transform.position);
        wb.WBChecked = false;
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
        
    }
    private void OnTriggerExit(Collider other)
    {
        wb.WBChecked = false;
    }
}
