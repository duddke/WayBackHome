using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFade : MonoBehaviour
{
    public Text text;
    public Text text2;

    void OnEnable()
    {
        text = GameObject.Find("Welcome Back Home").GetComponent<Text>();
        text2 = GameObject.Find("Mate").GetComponent<Text>();
        StartCoroutine(FadeTextToFullAlpha());
        StartCoroutine(FadeTextToFullAlpha2());
    }

    public IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 0.8f));
            yield return null;
        }
        //StartCoroutine(FadeTextToZero());
    }
    public IEnumerator FadeTextToFullAlpha2() // 알파값 0에서 1로 전환
    {
        text2.color = new Color(text2.color.r, text2.color.g, text2.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text2.color = new Color(text2.color.r, text2.color.g, text2.color.b, text2.color.a + (Time.deltaTime / 0.8f));
            yield return null;
        }
        //StartCoroutine(FadeTextToZero());
    }

    public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToFullAlpha());
    }
}
