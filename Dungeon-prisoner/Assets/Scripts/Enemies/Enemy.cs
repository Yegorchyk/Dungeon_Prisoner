using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int shockTime, maxShockTime;
    public bool TurnAround;
    public GameObject player;
    public bool left;

    public float speed;

    public GameObject Head;

    public float Vision;
    public Stats st;

    public GameObject AirAura, StoneAuraUlt;
    void Start()
    {
        anim = GetComponent<Animator>();
      
        st = GetComponent<Stats>();

      
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        speed = st.speed;
        
        if(st.hp <= 0)
        {
            if(Camera.main.GetComponent<DataBase>().Obj != null)
            {
                Instantiate(Camera.main.GetComponent<DataBase>().Obj, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
        if(anim.GetBool("GotDammage") == true)
        {
            shockTime++;
        }

        if(shockTime == maxShockTime)
        {
            anim.SetBool("GotDammage", false);

        }


        if (TurnAround == true)
        {
            if (transform.position.x < player.transform.position.x && piece == false)
            {
               
               
                left = false;

            }
            if(transform.position.x > player.transform.position.x && piece == false)
            {
               
                left = true;
            }

        }

        if(left == false)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
           
            RayPos.x = 1;

 
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
           
            RayPos.x = -1;

        }

        MoveInPiece();
       // Debug.Log(piece);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), true);

        if(AirAura != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, AirAura.transform.position, AirAura.GetComponent<AirAuraUlt>().speed);
        }


        //StoneAuraUlt
        
        
         if(Vector2.Distance(transform.position, StoneAuraUlt.transform.position) <= 1f && StoneAuraUlt.name != "Player")
        {
            player = StoneAuraUlt;
        }
      

    }

    public bool piece;
    public Transform pointLeft, pointRight;
    public int point;

    public GameObject Dir;
    public Transform RayStart;

    public Vector2 RayPos;

    public void MoveInPiece()
    {
       // Debug.Log(left);
       // Debug.Log(point);
        if(piece == true)
        {
            anim.SetBool("Walk", true);
            if(point == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, pointRight.transform.position, speed * Time.deltaTime);
                left = false;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, pointLeft.transform.position, speed * Time.deltaTime);
                left = true;
            }


            if(Vector2.Distance( transform.position , pointRight.transform.position) <= 1)
            {
                point = 1;
                left = false;
            }
             if (Vector2.Distance(transform.position , pointLeft.transform.position) <= 1 )
            {
                point = 0;
                left = true;
            }

           
        

      
        
            RaycastHit2D Attantion = Physics2D.Raycast(new Vector2(transform.position.x + RayPos.x, transform.position.y + RayPos.y), transform.right, Vision);
            Debug.DrawRay(new Vector2(transform.position.x + RayPos.x, transform.position.y + RayPos.y), transform.right * Vision, Color.white);


            // Debug.Log(Attantion.collider.tag);
            //Debug.Log(Time.deltaTime);
            if (Attantion.collider.tag == "Player" || st.hp < st.maxHp)
            {
                piece = false;
                anim.SetBool("Walk", false);
            }
        }
       


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "AirAuraUlt")
        {
            AirAura = collision.gameObject;
        }

        if (collision.gameObject.name == "PointLeft")
        {
           
        }

       

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log(collision.gameObject.tag);
    }
}
