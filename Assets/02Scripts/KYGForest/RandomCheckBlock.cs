using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�÷��̾ �����Ǹ�
//RandomBlock�� �������θ� true�� �����Ѵ�
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
