using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraUlt : MonoBehaviour
{
    private float ScaleX, ScaleY;
    public float dammage;

   
    public GameObject Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScaleX += 0.05f;
        ScaleY+= 0.05f;

        transform.localScale = new Vector2(transform.localScale.x + ScaleX, transform.localScale.y + ScaleY);
        if(transform.localScale.x >= 5 && transform.localScale.y >= 5)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Target = Target = collision.gameObject;
            Target.GetComponent<Stats>().hp -= dammage;

          
            
                Target.GetComponent<Stats>().mpEffect = 1;

              

            
        }
    }
}
