using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAuraUlt : MonoBehaviour
{
    public GameObject[] Enemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        
            for(int x = 0; x<Enemies.Length; x++)
            {
                if(Vector2.Distance(Enemies[x].transform.position, transform.position) <= 2)
                {
                    Enemies[x].GetComponent<Enemy>().StoneAuraUlt = gameObject;
                }
                
            }
          
        
    }
}
