using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    //배경을 스크롤 하고 싶다
    //스크롤 속도, 머티리얼
    public float speed = -100;
    RectTransform Ending;
    // Start is called before the first frame update
    void Start()
    {
        //머티리얼을 찾고 싶다
        //매쉬렌더러 컴포넌트가 있어야한다
        Ending = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //배경을 스크롤 하고 싶다
        //off셋이동하기
        Ending.anchoredPosition += Vector2.down * speed * Time.deltaTime;
    }
}
