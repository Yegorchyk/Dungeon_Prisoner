using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Animator anim;


    public GameObject MagAttak;
    public List<GameObject> formMagAttaks;

    public Stats stat;

    public bool magUlt;

    public Rigidbody2D rig;

    public Camera cam;

    public Inventory inv;

    public float Huy;

   
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stat = GetComponent<Stats>();
        cam = Camera.main;
        inv = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = stat.speed;
         Actions();
         Magic();
         Platforming();
         Moving();

        // Debug.Log(transform.position);
        //Debug.Log(Time.deltaTime);
        //Debug.Log(GetComponent<Inventory>().id[0]);

        GameObject.DontDestroyOnLoad(gameObject);

    }

    public bool Ismoving;
    public bool left;
    public bool isJumped;
    public float JumpForce;
    public void Moving()
    {
       
        if(Ismoving == true)
        {
            if (Input.GetKey("d"))
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                left = false;
                anim.SetBool("Walk", true);
                rig.gravityScale = 2.5f;
            }

            if (Input.GetKey("a"))
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                left = true;
                anim.SetBool("Walk", true);
                rig.gravityScale = 2.5f;
            }
        
        }

        if (left == true)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            RayposX = -0.27f;
        }

        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            RayposX = 0.27f;
        }


        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            anim.SetBool("Walk", false);
            Debug.LogError("Anim");
        }



        RaycastHit2D OnWall = Physics2D.Raycast(new Vector2(Head.transform.position.x + RayposX, Head.transform.position.y + RayposY), EdjeRayPosWall.transform.position, HitRayDis);
        Debug.DrawRay(new Vector2(Head.transform.position.x + RayposX, Head.transform.position.y + RayposY), EdjeRayPosWall.transform.position * HitRayDis , Color.red);

        //RaycastHit2D OnEdje = Physics2D.Raycast(new Vector2(Head.transform.position.x + RayposX, Head.transform.position.y + RayposY), EdjeRayPosEdje.transform.position, HitRayDis);
       /* Debug.DrawRay(new Vector2(Head.transform.position.x + RayposX, Head.transform.position.y + 1.9f), EdjeRayPosEdje.transform.position * HitRayDis, Color.green);*/

        // x = 0.18 y =1.9 dis = 0.25

        if (OnWall.collider.tag == "Ground")
        {
            //gameObject.transform.position = new Vector3(OnEdjeP.Evaluate(Time.deltaTime), OnEdjeP.Evaluate(Time.deltaTime), transform.position.z);
           

            Ismoving = false;
            curveJmp = false;
            jumpTime = 0;
            rig.simulated = false;
            anim.SetBool("OnEdje", true);
            //  gameObject.transform.position = new Vector3(OnEdjeP.Evaluate(curveTime), OnEdjeP.Evaluate(curveTime), transform.position.z);
            //transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);


        }

       // Debug.Log(OnWall.collider.tag);


    }

   

    public int hit;
    public int HitTime;
    public int maxHitTime;

    public bool AttackUlt;

    public int ulttime, maxUltTime;

 
    public string ult;
    public void Actions()
    {

        //Бойова система



      

        if (Input.GetMouseButton(0) && Time.timeScale == 1)
        {

            if (stat.Adrenalin > 0)
            {
                ulttime++;
            }

            if (ulttime >= maxUltTime)
            {
                AttackUlt = true;

            }

        }

        if (Input.GetMouseButtonUp(0) && Time.timeScale == 1)
        {
            ulttime = 0;
            if (AttackUlt == true)
            {
                
                AttackUlt = false;
                stat.Adrenalin -= 10;
                
                anim.Play(ult);
            }

            else
            { /*
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5 && anim.GetCurrentAnimatorStateInfo(0).IsName("ShortSwordHit") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("2ShortSwordHit") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("3ShortSwordHit") || hit == 0)
                {
                    hit += 1;

                    HitTime = 0;
                }*/
                // hit += 1;

                HitTime = 0;
                switch (hit)
                {
                    case 0:
                        anim.Play("ShortSwordHit");
                        hit += 1;
                        break;

                    case 1:

                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6 && anim.GetCurrentAnimatorStateInfo(0).IsName("ShortSwordHit"))
                        {
                           // Debug.Log("Hit2");
                            anim.Play("2ShortSwordHit");
                            hit += 1;
                        }
                        /*else 
                        {
                            Debug.Log("Hit2");
                            anim.Play("2ShortSwordHit");
                            hit += 1;
                        }*/
                        break;

                    case 2:
                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7 && anim.GetCurrentAnimatorStateInfo(0).IsName("2ShortSwordHit"))
                        {
                            anim.Play("3ShortSwordHit");
                            
                        }

                        hit = 0;
                        break;

                }

               
                
            }

            
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9 && anim.GetCurrentAnimatorStateInfo(0).IsName("ShortSwordHit") ||
               anim.GetCurrentAnimatorStateInfo(0).IsName("2ShortSwordHit") ||
               anim.GetCurrentAnimatorStateInfo(0).IsName("3ShortSwordHit")) ;
            {

                anim.SetInteger("Hit", 0);
                if (hit > 3)
                {
                    hit = 1;
                }
            }
           

        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Calm"))
        {
            hit = 0;
        }

        
        //Debug.Log(hit);

        
        if (hit > 0)
        {
            HitTime++;
        }

        if (HitTime >= maxHitTime || anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9 && anim.GetCurrentAnimatorStateInfo(0).IsName("3ShortSwordHit") /*||
           anim.GetCurrentAnimatorStateInfo(0).IsName("2ShortSwordHit") || anim.GetCurrentAnimatorStateInfo(0).IsName("3ShortSwordHit")*/)
        {
            anim.StopPlayback();            
            hit = 0;
            anim.SetInteger("Hit", 0);
        }
    }

    public GameObject Head;

    [SerializeField] private float HitRayDis;
    [SerializeField] private GameObject EdjeRayPosWall;
    [SerializeField] private GameObject EdjeRayPosEdje;
    public float RayposY;
    public float RayposX;  

    [SerializeField] private AnimationCurve JumpTraectory;
    [SerializeField] float jumpTime, maxJimpTime;
    private float jumpY;
    [SerializeField] private bool curveJmp;

    //Для драбин
    public bool OnDrabina;
    public Vector2 DrabObj;
    [SerializeField] private int DrabinaExitTime, maxDrabinaExitTime;
    [SerializeField] private bool noDrabina;

    public float DeshTime, maxDeshTime;
    private bool IsDesh;
    private float DeshX;
    [SerializeField] private AnimationCurve DeshCurve;
    
    public void Platforming()
    {


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            IsDesh = true;
            //rig.simulated = false;
            DeshX = transform.position.x;

        }
       // Debug.Log(IsDesh);


        if (IsDesh == true)
        {
            // for(DeshTime = 0; DeshTime <= maxDeshTime; DeshTime += Time.deltaTime)
            // {
            stat.takeDammage = false;
            rig.gravityScale = 0;
            DeshTime += Time.deltaTime;
            if (DeshTime >= maxDeshTime)
            {
                IsDesh = false;
                DeshTime = 0;
                rig.simulated = true;
                stat.takeDammage = true;
                rig.gravityScale = 2.5f;
                //transform.position = new Vector3(DeshX + DeshCurve.l, transform.position.y, transform.position.z);
                DeshX = transform.position.x;
                transform.position = new Vector3(DeshX /*+ DeshCurve.Evaluate(DeshTime)*/, transform.position.y, transform.position.z);
            }

            if(left == true)
            {
                transform.position = new Vector3(DeshX + DeshCurve.Evaluate(DeshTime) * -1, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(DeshX + DeshCurve.Evaluate(DeshTime), transform.position.y, transform.position.z);
            }
            

               
            

           

        }

        if (Input.GetKeyDown(KeyCode.Space) && isJumped == false)
        {
            anim.Play("Jump");
            rig.AddForce(Vector2.up * JumpForce);
            jumpY = transform.position.y;
            isJumped = true;
            curveJmp = true;
            anim.SetBool("IsJump", isJumped);

            OnDrabina = false;
            Ismoving = true;
        }

        if (curveJmp == true)
        {
            jumpTime += Time.deltaTime;
            if (jumpTime > maxJimpTime)
            {
                curveJmp = false;
                jumpTime = 0;
                //Debug.Log(rig.velocity);
                //rig.velocity = new Vector3(0, 0, 0);
            }

            float progress = jumpTime / maxJimpTime;




            transform.position = new Vector3(transform.position.x, jumpY + JumpTraectory.Evaluate(jumpTime), transform.position.z);
        }




        //Карабкання на уступи

        // var curveTime = OnEdjeP.keys.Length;

        //Ray rayOnWall = new Ray(new Vector2(Head.transform.position.x + 0.3f, Head.transform.position.y + 1f), Vector2.right);
      






        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9 && anim.GetCurrentAnimatorStateInfo(0).IsName("OnEdje"))
        {


            anim.SetBool("OnEdje", false);

        }

        //Debug.Log(OnWall.collider.tag );
        //Debug.Log(OnEdje.collider.tag);
        //.Log(OnWall.collider.tag == "Ground" && OnEdje.collider.tag != "Ground");
        //Debug.Log(OnWall.collider.tag == "Ground");
        // Debug.Log(OnEdje.collider.tag != "Ground");
        //Debug.Log(OnWall.collider.tag == "Ground" && OnEdje.collider.tag != null);



        //Драбини
        if (OnDrabina == true)
        {
            RaycastHit2D ondrabCheck = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1), Vector3.forward, 10);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 1), Vector3.forward * 1, Color.red);

            rig.gravityScale = 0;

            if (Input.GetKey("w"))
            {

                Ismoving = false;
                transform.Translate(Vector2.up * Time.deltaTime * speed);
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ground"), LayerMask.NameToLayer("Player"), true);
                //Debug.LogError("W");
               // transform.position = new Vector2(DrabObj.x - 0.2f, transform.position.y);
            }
           


            if (Input.GetKey("s"))
            {
                //rig.gravityScale = 0;
                Ismoving = false;
                transform.Translate(Vector2.down * Time.deltaTime * speed);
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ground"), LayerMask.NameToLayer("Player"), true);
          
                //transform.position = new Vector2(DrabObj.x - 0.2f, transform.position.y);
            }
           



        }
        else
        {
            rig.gravityScale = 2.5f;
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ground"), LayerMask.NameToLayer("Player"), false);
        }

        if (Input.GetKeyUp("w"))
        {
            Ismoving = true;
           // Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ground"), LayerMask.NameToLayer("Player"), false);
        }

        if (Input.GetKeyUp("s"))
        {
            Ismoving = true;
           // Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ground"), LayerMask.NameToLayer("Player"), false);
        }


       


        // Debug.Log(OnDrabina);
        //Debug.Log(rig.gravityScale);



    }


    public int magulttime, maxMagUltTime;
    public Transform magAtkTrn;
    public void Magic()
    {
        if (Input.GetMouseButtonDown(1))
        {
           
        }

        if (Input.GetMouseButton(1))
        {

            if (stat.mp > 0)
            {
                magulttime++;
            }

            if (magulttime >= maxMagUltTime)
            {
                magUlt = true;
               
            }
         
        }

        Debug.Log(magulttime);
        if (Input.GetMouseButtonUp(1))
        {
            magulttime = 0;
           if(magUlt == true)
            {
                
                MagAttak = Instantiate(inv.Weapons[2], magAtkTrn.position, transform.rotation);
                MagAttak.GetComponent<MagicBolt>().Shooter = gameObject;
                MagAttak.GetComponent<MagicBolt>().enmTag = "Enemy";

                MagAttak.transform.localScale = new Vector2(MagAttak.transform.localScale.x + 1, MagAttak.transform.localScale.y + 1);
                MagAttak.GetComponent<MagicBolt>().dammage = stat.magdammage * 2;
                MagAttak.GetComponent<MagicBolt>().mpEffectProbability = 100;
                MagAttak.GetComponent<MagicBolt>().element = stat.ChosenElement;
                MagAttak.GetComponent<MagicBolt>().Ult = true;
                MagAttak.GetComponent<MagicBolt>().AuraUlts[stat.ChosenElement - 1].GetComponent<IceAuraUlt>().Shooter = gameObject;
                magUlt = false;
                stat.mp -= 20;
            }

            else
            {
                if (stat.mp > 0)
                {
                   // Debug.Log("MgAtk");
                    MagAttak = Instantiate(inv.Weapons[2], magAtkTrn.position, transform.rotation);
                   
                    Debug.Log(MagAttak.GetComponent<MagicBolt>().Ult);

                    MagAttak.GetComponent<MagicBolt>().Shooter = gameObject;
                    MagAttak.GetComponent<MagicBolt>().enmTag = "Enemy";

                    MagAttak.GetComponent<MagicBolt>().dammage = stat.magdammage;
                    MagAttak.GetComponent<MagicBolt>().mpEffectProbability = stat.mpEffectProbability;
                    MagAttak.GetComponent<MagicBolt>().element = stat.ChosenElement;
                   
                    stat.mp -= 5;
                }
            }
           
        }
    }



    public void OnTriggerExit2D(Collider2D collision)
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
           // Debug.Log("Jmp");
            isJumped = false;
            anim.SetBool("IsJump", isJumped);
            curveJmp = false;
            jumpTime = 0;

          
        }

      

        /* if(collision.gameObject.tag == "Finish")
         {
             cam.GetComponentInChildren<CameraMove>().LastPos = new Vector2(cam.transform.position.x, cam.transform.position.y);
             cam.GetComponentInChildren<CameraMove>().move = true;
         }*/



    }



    [SerializeField] private Transform DeshXPos;
  

    public void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log(collision.gameObject.tag);
        curveJmp = false;
        IsDesh = false;

        if(collision.gameObject.tag == "Fon" || collision.gameObject.tag == "Ground" && IsDesh == true)
        {
      
                transform.position = new Vector3(DeshXPos.position.x, transform.position.y, transform.position.z);
            
                
                IsDesh = false;
            
           
           
            Debug.Log("Wall");
        }
    }
   


}


