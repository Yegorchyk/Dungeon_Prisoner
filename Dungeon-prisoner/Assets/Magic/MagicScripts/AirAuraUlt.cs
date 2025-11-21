using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAuraUlt : MonoBehaviour
{
    public GameObject Shooter;
    public GameObject Target;
    public float speed, dammage, dis;

    public float time, maxTime;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 0.1f, transform.rotation.w);
        time++;
        if (time >= maxTime)
        {
            Destroy(gameObject);
        }

        
        
            
            if (Vector2.Distance(Target.transform.position, gameObject.transform.position) <= dis)
            {
                Target.GetComponent<Stats>().hp -= dammage;
               // Target.transform.position = Vector2.MoveTowards(Target.transform.position, transform.position, speed);
            }
        


    }

  
    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Enemy")
        {
          
            
                if(Target == null)
                {
                    Target = collision.gameObject;
                }
               
            



        }



    }
}
