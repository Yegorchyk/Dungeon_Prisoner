using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
  public GameObject Player;


    public void Update()
    {
        Player = GameObject.Find("Player");
       
       
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
     
       
        if (collision.gameObject.tag == "Player")
        {

           Player.GetComponent<Player>().OnDrabina = true;



        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            //noDrabina = true;

            Player.GetComponent<Player>().OnDrabina = false;
            /* rig.gravityScale = 2.5f;
         Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ground"), LayerMask.NameToLayer("Player"), false);
         */

        }


    }

    public void OnTriggerStay2D(Collider2D collision)
    {
    
        if (collision.gameObject.tag == "Player")
        {

            Player.GetComponent<Player>().OnDrabina = true;


        }
    }
}
