using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kislota : MonoBehaviour
{
    public GameObject Target;
    public string targetName;

    public bool noStatic;
    public float statictime, maxstatictime;

    public void Update()
    {

        if(noStatic == true)
        {
            statictime++;

            if (statictime >= maxstatictime && noStatic == false)
            {
                Destroy(gameObject);
            }
        }
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetName)
        {
            Target = collision.gameObject;
            Target.GetComponent<Animator>().StopPlayback();
            Target.GetComponent<Stats>().kislota = true;


        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetName)
        {
            Target = collision.gameObject;
            Target.GetComponent<Animator>().StopPlayback();
            Target.GetComponent<Stats>().kislota = true;


        }

    }


}
