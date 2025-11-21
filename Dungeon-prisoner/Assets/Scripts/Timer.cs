using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time, maxTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time >= maxTime)
        {
            Destroy(gameObject);
        }
    }
}
