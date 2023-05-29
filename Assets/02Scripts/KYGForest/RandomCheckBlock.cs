using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어가 감지되면
//RandomBlock의 감지여부를 true로 변경한다
public class RandomCheckBlock : MonoBehaviour
{
    RandomBlock rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<RandomBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        rb.isChecked = true;
    }

    private void OnTriggerExit(Collider other)
    {
        rb.isChecked = false;
    }
}
