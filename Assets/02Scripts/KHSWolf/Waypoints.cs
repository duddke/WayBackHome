using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Transform[] waypoints;
    // Update is called once per frame
    void Update()
    {
        
    }
}
