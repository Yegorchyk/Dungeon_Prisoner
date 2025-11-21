using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMan : MonoBehaviour
{
    public Stats st;
    public Enemy enemy;
    public Animator anim;
    public GameObject player;
    public GameObject Hammer, HammerPos;

    [SerializeField] private float atkDis;
    [SerializeField] private int atkTime, maxAtkTime;
    [SerializeField] private int hitTime, maxHitTime;

    public bool walk;

    public float speed;
    void Start()
    {
        st = GetComponent<Stats>();
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        player = GetComponent<Enemy>().player;
        if (enemy.piece == false)
        {
            Fight();
        }
   
       
    }


    public void Fight()
    {
        atkTime++;
        if (atkTime > maxAtkTime)
        {
            atkTime = 0;
        }

        if (walk == true && Vector2.Distance(gameObject.transform.position, player.transform.position) <= atkDis && GetComponent<Stats>().mpEffect != 3 && atkTime == maxAtkTime)
        {
            anim.SetBool("Attack", true);


        }
        else if (Vector2.Distance(gameObject.transform.position, player.transform.position) > atkDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        hitTime++;
        if (hitTime > maxHitTime)
        {
            hitTime = 0;
        }
        if (walk == true && Vector2.Distance(gameObject.transform.position, player.transform.position) <= atkDis / 3 && GetComponent<Stats>().mpEffect != 3 && hitTime == maxHitTime && anim.GetBool("Attack") == false)
        {
            anim.SetBool("Hit", true);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8 && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            anim.SetBool("Hit", false);
        }
    }
}
