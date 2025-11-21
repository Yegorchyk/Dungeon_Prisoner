using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour
{

    public void Start()
    {
       /* if (GetComponentInChildren<Collider2D>().tag == "Fon")
        {
            gameObject.SetActive(false);
        }*/

        //Debug.Log(GetComponentInChildren<Collider2D>().tag);
    }

    public void Update()
    {
       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }


    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fon")
        {
            gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
      

       // Debug.Log("Trig");
    }
}
