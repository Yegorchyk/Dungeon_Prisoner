using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingOfRats : MonoBehaviour
{
    public bool walk;
    public GameObject player;
    public float speed;
    public Animator anim;

    public Enemy enm;
    public Stats st;
    private GameObject canvas;

    public GameObject Rat;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        enm = GetComponent<Enemy>();
        st = GetComponent<Stats>();

        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<Bar>().BossHpBar.SetActive(true);
        canvas.GetComponent<Bar>().Boss = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (enm.piece == false) 
        { if(st.hp <= 0)
            {
                PlayerPrefs.SetFloat("Expirience", PlayerPrefs.GetFloat("Expirience") + 25);
            }
            transform.position = new Vector2(transform.position.x, -2.35f);
           
            if ( Vector2.Distance(transform.position, player.transform.position) > 2 && atkNum == 0 )
            {
                 if(atkNum == 0)
                 {
                walk = true;
                 }
         
           

             }


            else
            {
                anim.SetBool("Walk", false);
                walk = false;
            }

            if (walk == true)
            {
               transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                anim.SetBool("Walk", true);
            }
        
      
        
            Attaks();
            Actions();
        }
       

       




    }

    public int atkNum;
    public float atkTime, maxAtkTime;
    public void Attaks()
    {
       // Debug.Log(atkNum);
       
        
        if(atkTime >= maxAtkTime)
        {
             atkNum = Random.Range(0, 4);
            //atkNum = 3;
            atkTime = 0;
        }
        else
        {
            atkTime++;
        }

        switch(atkNum)       
        {
            case 0:
                {
                    enm.TurnAround = true;
                }
                break;
            case 1:
                if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 4)
                {
                    enm.TurnAround = false;
                    walk = false;
                    anim.Play("KuvaldaHit");
                    atkNum = 0;
                    atkTime = 0;
                }
                break;
            case 2:

                if(st.maxHp / st.hp >= 2)
                {
                    walk = false;
                    atkTime = 0;
                    enm.TurnAround = false;
                    if (anim.GetBool("Run") == false)
                    {
                        anim.Play("Ryk");
                    }


                    if (anim.GetBool("Run") == true)
                    {
                        if (enm.left == false)
                        {
                            transform.Translate(Vector2.right * 10f * Time.deltaTime);
                        }
                        else if (enm.left == true)
                        {
                            transform.Translate(Vector2.right * 10f * Time.deltaTime);
                        }

                    }
                }
               
                break;

            case 3:

                if(Rat == null)
                {
                    enm.TurnAround = false;
                    walk = false;
                    atkNum = 0;
                    atkTime = 0;
                    anim.Play("Zov");
                }
               
                break;

        }
      
      
    }

   
    public bool coughtRat;
    public Transform kihty;
    public void Actions()
    {



        //Debug.Log(Vector2.Distance(transform.position, Rat.transform.position));
       
       

        if (st.hp <= st.maxHp / 4)
        {
           
            if (Rat != null)
            {
                
                
                walk = false;

             
                atkNum = 0;
                if (Vector2.Distance(transform.position, Rat.transform.position) <= 3)
                {
                    
                    Rat.GetComponent<Rat>().walk = false;
                    anim.Play("EatRat");
                    atkTime = 0;
                    if (coughtRat == true)
                    {
                        Rat.transform.position = kihty.transform.position;
                    }


                }
                else if(coughtRat == false)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Rat.transform.position, speed);
                }
            }


            
        }
    }

   

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
              atkNum = 0;
                anim.SetBool("Run", false);           
        }      
    }

  
}
