using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    Pause pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponentInParent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonResume()
    {
        pause.PauseMenu.SetActive(false);
        Time.timeScale = 1;
        pause.IsPause = false;
    }
}
