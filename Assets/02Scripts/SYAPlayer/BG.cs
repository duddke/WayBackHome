using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    //����� ��ũ�� �ϰ� �ʹ�
    //��ũ�� �ӵ�, ��Ƽ����
    public float speed = -100;
    RectTransform Ending;
    // Start is called before the first frame update
    void Start()
    {
        //��Ƽ������ ã�� �ʹ�
        //�Ž������� ������Ʈ�� �־���Ѵ�
        Ending = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //����� ��ũ�� �ϰ� �ʹ�
        //off���̵��ϱ�
        Ending.anchoredPosition += Vector2.down * speed * Time.deltaTime;
    }
}
