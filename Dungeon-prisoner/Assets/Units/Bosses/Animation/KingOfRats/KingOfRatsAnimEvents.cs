using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingOfRatsAnimEvents : MonoBehaviour
{
    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
  
    public void Run()
    {
        anim.SetBool("Run", true);
    }

    public Transform hitpos;
    public GameObject BombOfKislota;

    public void OnHit1()
    {
        Instantiate(BombOfKislota, hitpos.position, Quaternion.identity);
    }

    [SerializeField] private Transform[] ratspawn;
    public GameObject Rat, newRat;
    public void Zov()
    {
        for(int x = 0; x < 5; x++)
        {
          newRat =  Instantiate(Rat, ratspawn[Random.RandomRange(0, 2)].transform.position, Quaternion.identity);
            if(GetComponent<KingOfRats>().Rat == null)
            {
                GetComponent<KingOfRats>().Rat = newRat;
            }
           
            newRat.GetComponent<Enemy>().piece = false;
        }
        //Instantiate(Rat, ratspawn[Random.RandomRange(0, 2)].transform.position, Quaternion.identity);
    }

    public void Catch()
    {
        GetComponent<KingOfRats>().coughtRat = true;
        GetComponent<KingOfRats>().Rat.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void Eaten()
    {
        Destroy(GetComponent<KingOfRats>().Rat);
        GetComponent<Stats>().hp += 25;
    }
}
