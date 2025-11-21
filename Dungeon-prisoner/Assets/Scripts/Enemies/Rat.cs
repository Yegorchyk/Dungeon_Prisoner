using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public Animator anim;

    public bool walk;

    public int PlayerLayer, ObjLayer;

    public float getdamTime, maxgetdamTime;

    [Header("Scripts")]
    public Stats st;
    public Enemy enemy;

   [SerializeField] private int atkTime, maxAtkTime;
    void Start()
    {
        anim = GetComponent<Animator>();
        st = GetComponent<Stats>();
        enemy = GetComponent<Enemy>();
       
    }

    // Update is called once per frame
    void Update()
    {
        player = GetComponent<Enemy>().player;
        speed = st.speed;

        if(atkTime < maxAtkTime)
        {
            atkTime++;
        }
        if(enemy.piece == false)
        {
            speed = GetComponent<Stats>().speed;
            if (walk == true && Vector2.Distance(gameObject.transform.position, player.transform.position) > 0.6 && GetComponent<Stats>().mpEffect != 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }


            if (Vector2.Distance(gameObject.transform.position, player.transform.position) < 0.8 && atkTime >= maxAtkTime)
            {
                anim.SetBool("Bite", true);
                walk = false;
                atkTime = 0;
            }

            else
            {
                anim.SetBool("Bite", false);
                walk = true;

            }


            if (anim.GetBool("GotDammage") == true)
            {
                anim.SetBool("Bite", false);
                getdamTime++;
                walk = false;
            }

            if (getdamTime >= maxgetdamTime)
            {
                anim.SetBool("GotDammage", false);
                walk = true;
                getdamTime = 0;

            }



            if (st.hp <= 0)
            {
               // Destroy(gameObject);
            }
        }
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {       
                anim.SetBool("Bite", true);
                walk = false;                     
        }
     
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetBool("Bite", false);
            walk = true;
        }
    }
}
