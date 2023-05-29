using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
    bool check = false;
    public bool textcolorFade;
    public bool fadein;
    public Image image;

    public Text tx;
    public string m_text = "New Text";
    AudioSource typingSound;
    public AudioSource Bg;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
        typingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            check = true;
        }
        textColorFade();
        Fadein();
    }
    IEnumerator _typing()
    {

        yield return new WaitForSeconds(2f);

        for (int i = 0; i <= m_text.Length; i++)
        {
            if (check == false)
            {
                typingSound.Play();
                tx.text = m_text.Substring(0, i);

                yield return new WaitForSeconds(0.15f);
            }
            else
            {
                tx.text = m_text;

            }
        }
        check = false;
        yield return new WaitForSeconds(2);
        textcolorFade = true;
        

    }
    void textColorFade()
    {
        if (textcolorFade)
        {
            tx.color = Color.Lerp(tx.color, Color.clear, 2 * Time.deltaTime);
            if (tx.color.a<=0.001f)
            {
                textcolorFade = false;
                fadein = true;
                Bg.Play();
            }
        }     
    }
    void Fadein()
    {
        if (fadein)
        {
            image.color = Color.Lerp(image.color, Color.clear, 1.5f * Time.deltaTime);
            if (image.color==Color.clear)
            {
                
                fadein = false;
            }

        }

    }


    //new Color(tx.color.r, tx.color.g, tx.color.b, 0)
}
