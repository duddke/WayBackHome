using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Onending : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==LayerMask.NameToLayer("Player"))
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
}
