using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    public GameObject dammage;
    public Transform damPos;

    public Zomby zomby;
    public RatMan ratman;
    public Animator anim;
    public void Start()
    {
        zomby = GetComponent<Zomby>();
        ratman = GetComponent<RatMan>();
        anim = GetComponent<Animator>();
    }
    public void Damage()
    {
        dammage.SetActive(true);
        dammage.transform.position = damPos.position;
       
        
    }

    public void NoDammage(string boolName)
    {
        dammage.SetActive(false);
        anim.SetBool(boolName, false);
        //zomby.IsDesh = false; 
    }

    public void ZombyAtack()
    {
        zomby.IsDesh = true;
        zomby.anim.Play("Ryvok");
        

    }

   

    public void RatmanAttack()
    {
        Instantiate(ratman.Hammer, ratman.HammerPos.transform.position, gameObject.transform.rotation);
        //ratman.anim.SetBool("Attack", false);
      
    }

    public void RatmanAttackEnd()
    {
        ratman.anim.SetBool("Attack", false);
    }
}
