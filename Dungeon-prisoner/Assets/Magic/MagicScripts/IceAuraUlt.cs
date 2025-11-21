using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAuraUlt : MonoBehaviour
{
    public GameObject Shooter, Target;
    public float speed, dammage, dis;

    public float time, maxTime;
    void Start()
    {
        transform.parent = Shooter.transform;
        transform.position = new Vector2(Shooter.transform.position.x + 8, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if(time >= maxTime)
        {
            Destroy(gameObject);
        }

        Vector3 BossPoz, Poz;
        BossPoz = Shooter.transform.position;
        Poz = gameObject.transform.position;

        BossPoz.x = BossPoz.x - Poz.x;
        BossPoz.y = BossPoz.y - Poz.y;

        float angle = Mathf.Atan2(BossPoz.y, BossPoz.x) * Mathf.Rad2Deg;
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        transform.rotation = (Quaternion.Euler(new Vector3(0, 0, angle)));

        if(Vector2.Distance(transform.position, Shooter.transform.position) > dis)
        {
            transform.position = Vector2.MoveTowards(transform.position, Shooter.transform.position, speed);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Target = collision.gameObject;

        if(Target != Shooter)
        {
            Target.GetComponent<Stats>().hp -= dammage;
            Target.GetComponent<Stats>().mpEffect = 2;
        }
       

           

        
    }
}
