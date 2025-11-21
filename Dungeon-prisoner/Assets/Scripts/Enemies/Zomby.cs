using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomby : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public Animator anim;
    public Stats st;

    public bool walk;
    public bool left;

    public GameObject AtackTrigger;

    [SerializeField] private bool TurnAround;
    [SerializeField] private Enemy enemy;
    void Start()
    {
        anim = GetComponent<Animator>();
        st = GetComponent<Stats>();
        speed = st.maxSpeed;
        enemy = GetComponent<Enemy>();


        maxDeshTime = 0.29f;
    }

    // Update is called once per frame
    void Update()
    {
       
        player = GetComponent<Enemy>().player;
        speed = st.speed;
        if (enemy.piece == false)
        {
            Attack();

            if (TurnAround == true)
            {
                if (transform.position.x < player.transform.position.x)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), true);
                    left = false;

                }
                else
                {
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                    Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), true);
                    left = true;
                }

            }

            if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 1.5)
            {
                //atkTime -= 1;
                //anim.SetBool("Atack", false);
                //Debug.Log(IsDesh);
            }
        }


        //Debug.Log(Vector2.Distance(gameObject.transform.position, player.transform.position));
        //Debug.Log(IsDesh);

       // Debug.Log(DeshTime);
    
    }

    [SerializeField] private AnimationCurve DeshCurve;
    public float DeshTime, maxDeshTime;
    public  bool IsDesh;
    public  float DeshX;

    public float atkDis;

    public int atkTime, maxAtkTime;
    public void Attack()
    {
        
        if(atkTime < maxAtkTime)
        {
            atkTime++;
        }
        if (walk == true && Vector2.Distance(gameObject.transform.position, player.transform.position) <= atkDis && GetComponent<Stats>().mpEffect != 3 && atkTime >= maxAtkTime && IsDesh == false)
        {

            anim.SetBool("Atack", true);
            anim.SetBool("Walk", false);

        }

        else
        {
            if(walk == true && GetComponent<Stats>().mpEffect != 3 && Vector2.Distance(gameObject.transform.position, player.transform.position) > atkDis)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                anim.SetBool("Walk", true);
            }
        }
        //Debug.Log(DeshX);

        if (IsDesh == true)
        {
            // for(DeshTime = 0; DeshTime <= maxDeshTime; DeshTime += Time.deltaTime)
            // {
            //Debug.Log(transform.position.x);
            AtackTrigger.SetActive(true);
            DeshTime += Time.deltaTime;
            TurnAround = false;

            if (DeshTime <= maxDeshTime)
            {
                DeshX = transform.position.x;

            }
             
            if (DeshTime >= maxDeshTime)
            {
               
                IsDesh = false;
                AtackTrigger.SetActive(false);               
                DeshTime = 0;
                atkTime = 0;
                TurnAround = true;
                //transform.position = new Vector3(DeshX + DeshCurve.l, transform.position.y, transform.position.z);
                //Vector2 DeshPos = transform.TransformPoint(transform.localPosition);
                DeshX = transform.position.x;
                transform.position = new Vector3(DeshX /*+ DeshCurve.Evaluate(DeshTime)*/, transform.position.y, transform.position.z);
            }


            if(TurnAround == false)
            {
                if (left == true)
                {
                    transform.position = new Vector3(DeshX + DeshCurve.Evaluate(DeshTime) * -1 / 4, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(DeshX + DeshCurve.Evaluate(DeshTime) / 4, transform.position.y, transform.position.z);
                }
            }
           
        }
    }


    [SerializeField] private Transform DeshXPos;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Player")
        {
            IsDesh = false;
        }


       
        IsDesh = false;

        if (collision.gameObject.tag == "Fon" || collision.gameObject.tag == "Ground" && IsDesh == true)
        {

            transform.position = new Vector3(DeshXPos.position.x, transform.position.y, transform.position.z);


            IsDesh = false;



            Debug.Log("Wall");
        }
    }

}

  


   