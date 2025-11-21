using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stats : MonoBehaviour
{
    public float hp;
    public float maxHp;

    public float def;
    public float maxDef;

    public float mpDef, maxmpDef;

    public float Adrenalin, maxAdrenalin;
    public float mp, maxMp;

    public float dammage, magdammage;
    public float maxDammage, maxMagDammage;

    public int MagForm; //форма закляття

    public float mpEffectProbability; // Ймовірність крит ефекта магії
    public int mpEffect; // Який саме ефект накладений 1-вогонь, 2-вода, 3-повітря, 4-земля.

    public int EffectTIme, maxEffectTime; //періодичність ефекту.
    public int EffectTimeScale, maxEffectTimeScale;

    public float speed, maxSpeed;

    public int ChosenElement; // обрана стихія закляття

    public bool takeDammage;

    void Start()
    {
        hp = maxHp;
        def = maxDef;
        mp = maxMp;
        dammage = maxDammage;
        magdammage = maxMagDammage;
        Adrenalin = maxAdrenalin;
        speed = maxSpeed;
        takeDammage = true
;
       // Debug.Log(mp);
    }

   
    void Update()
    {
       
      

        MagicEffects();
        PhysicsEffects();


    }

    public bool kislota;
    private int kisTIme, maxKisTime, kisObm;
   [SerializeField] private int damChangeTime, maxDamChangeTime;
    public void PhysicsEffects()
    {
      
        int maxtime = 5;
        maxKisTime = 30;
        if (kislota == true && kisObm <= maxtime)
        {
            kisTIme++;
            if (kisTIme == maxKisTime)
            {
                hp -= 10 / (0.2f * def);
                
                kisTIme = 0;
                kisObm += 1;

                if( dammage > 0)
                {
                    dammage -= 1;
                }

            }
            if (kisObm >= maxtime)
            {
                damChangeTime += 1;
                kisTIme = 0;
                kisObm = 0;
                kislota = false;
            }

        }

        if (damChangeTime > 0 )
        {
            damChangeTime++;
        }

        if (damChangeTime >= maxDamChangeTime )
        {
            dammage = maxDammage;
            damChangeTime = 0;
        }
       
    }
    public void MagicEffects()
    {

        if(mpEffect > 0)
        {
            EffectTimeScale++;
        }
        else
        {
            EffectTimeScale = 0;
        }

        if(EffectTimeScale >= maxEffectTimeScale)
        {
            EffectTimeScale = 0;
            mpEffect = 0;
            def = maxDef;
        }



        switch (mpEffect)
        {
            case 1: //вогонь


                maxEffectTime = 100;
                EffectTIme++;

                if (EffectTIme >= maxEffectTime)
                {
                    hp -= maxHp/7;

                    EffectTIme = 0;
                }


                break;

            case 2: //заморозка

                maxEffectTime = 500;
                EffectTIme++;

                int scale = 0;


                speed = maxSpeed = 0;
                GetComponent<Enemy>().piece = true;
                GetComponent<Enemy>().TurnAround = false;



                if (EffectTIme >= maxEffectTime)
                {
                    speed = maxSpeed;

                    EffectTIme = 0;
                    mpEffect = 0;
                    GetComponent<Enemy>().piece = false;
                }

                Debug.Log(speed);
                break;

            case 3: //повітря

               
                
                    speed = 0;
                   
                  

                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

                    EffectTIme = 0;
                    mpEffect = 0;
                mpEffect = 0;
                speed = maxSpeed;
                break;
                

               

               

            case 4: //земля


                maxEffectTime = 10;
                EffectTIme++;

                if (EffectTIme >= maxEffectTime)
                {
                    def -= maxDef * 0.1f;

                    EffectTIme = 0;
                    mpEffect = 0;
                }

                break;

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Kislota")
        {
            kislota = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Kislota")
        {
            kislota = false;
        }
        
    }
}
