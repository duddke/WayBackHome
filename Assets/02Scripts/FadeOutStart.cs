using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutStart : MonoBehaviour
{
    public Image image;

   public bool StartSceneChage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (StartSceneChage)
        {

        image.color = Color.Lerp(image.color, Color.black, 9f * Time.deltaTime);
        if (image.color.a >= 0.99f)
        {
            
            SceneManager.LoadScene("MainMap");
        }
        }
    }

    public void FadeoutTrigger()
    {
        StartSceneChage = true;
    }
}
