using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingQuit : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickQUIT()
    {
        Application.Quit();
        Debug.Log("종료버튼");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
