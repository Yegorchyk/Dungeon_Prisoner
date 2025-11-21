using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBolt : MonoBehaviour
{

   public string  enmTag;
    public int element;

    public int magForm;
    public float speed;
    public GameObject Target;

    public float dammage;

    public float mpEffectProbability;

    public Animator anim;

    public GameObject Shooter;



    [SerializeField] private int time, maxTime;
    public bool Ult;

    public List<GameObject> AuraUlts = new List<GameObject>();
    // Update is called once per frame

    public void Start()
    {
        anim = GetComponent<Animator>();
        magForm = Shooter.GetComponent<Stats>().MagForm;
    }
    void Update()
    {
        Debug.Log(Shooter);
        // 0-куля, 1-аура
        if(Ult == false)
        {
            switch (magForm)
            {
                case 0:

                    transform.Translate(Vector2.right * Time.deltaTime * speed);

                    switch (element)
                    {
                        case 1:
                            anim.Play("FireBall");

                            break;

                        case 2:
                            anim.Play("IceBall");
                            break;

                        case 3:
                            anim.Play("WindBall");

                            break;
                    }
                    break;

                case 1://Аура

                    //Physics2D.IgnoreLayerCollision(gameObject.layer, Shooter.layer, true);
                    switch (element)
                    {
                        case 1:

                            anim.Play("Fire Aura");
                           
                            break;
                    }
                    maxTime = 300;
                    time++;
                    if (time >= maxTime)
                    {
                        Destroy(gameObject);
                    }

                    transform.position = new Vector2(Shooter.transform.position.x, Shooter.transform.position.y);
                    // GetComponent<CircleCollider2D>().radius = 1f;

                    if (Vector2.Distance(Target.transform.position, transform.position) <= 1)
                    {
                        Target.GetComponent<Stats>().hp -= dammage;
                        if (Random.Range(0, 100) < mpEffectProbability / 2)
                        {
                            if (element == 3)
                            {
                                if (Target.transform.position.x > Shooter.transform.position.x)
                                {
                                    Target.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300);
                                }
                                else
                                {
                                    Target.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 300);
                                }

                            }
                        }
                    }



                    break;

            }
        }

        Ults();


    }

  

    public void Ults()
    {
        if(Ult == true)
        {
            Debug.Log("Ult");
            switch (magForm)
            {
                case 1:

                    Instantiate(AuraUlts[element - 1], transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;

                case 2:
                    GameObject ult;
                    ult = Instantiate(AuraUlts[element - 1], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                    ult.GetComponent<IceAuraUlt>().Shooter = Shooter;
                    Destroy(gameObject);
                    break;

                case 3:

                    GameObject ult1;
                    ult1 = Instantiate(AuraUlts[element - 1], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                    ult1.GetComponent<AirAuraUlt>().Shooter = Shooter;
                    Destroy(gameObject);
                    break;

                case 4:
                    GameObject ult2;
                    ult2 = Instantiate(AuraUlts[element - 1], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                    ult2.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300);
                    break;
            }
           
        }

      
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enmTag)
        {

            Target = collision.gameObject;
            Target.GetComponent<Stats>().hp -= dammage;



            if (Random.Range(0, 100) < mpEffectProbability)
            {
                Target.GetComponent<Stats>().mpEffect = element;

                if (element == 3)
                {
                    if (Target.transform.position.x > Shooter.transform.position.x)
                    {
                        Target.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300);
                    }
                    else
                    {
                        Target.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 300);
                    }

                }

            }

            if (magForm == 0)
            {
                Destroy(gameObject);
            }


        }
    }

}
