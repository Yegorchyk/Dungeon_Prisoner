using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrig : MonoBehaviour
{
    public float damage;
    public GameObject Target;
    public GameObject Fighter;
    public string targetName;

    public void Start()
    {
       
    }

    public void FixedUpdate()
    {
        damage = Fighter.GetComponent<Stats>().dammage;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
      
        if (collision.gameObject.tag == targetName )
        {
           // Debug.Log("Touch");
           
            Target = collision.gameObject;

            if (Target.GetComponent<Stats>().takeDammage == true)
            {
                //Debug.Log("Hit");
                Target.GetComponent<Stats>().hp -= damage / (0.2f * Target.GetComponent<Stats>().def);
                Target.GetComponent<Animator>().Play("GotDammage");

            }
            Target.GetComponent<Animator>().StopPlayback();
            

            if (GetComponent<Hammer>() != null)
            {
                Destroy(gameObject);
            }
            //Debug.Log(damage);
          
        }
    }

    public void Update()
    {
    // Debug.Log(Target.GetComponent<Stats>().hp -= damage / (0.2f * Target.GetComponent<Stats>().def));
    }


    public void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(gameObject.transform.position, GetComponent<CircleCollider2D>().radius);
    }
}
