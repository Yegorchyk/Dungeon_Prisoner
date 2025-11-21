using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChacker : MonoBehaviour
{
    public Enemy enemy;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
             Debug.Log("Huy");
                RaycastHit2D Attantion = Physics2D.Raycast(enemy.Head.transform.position, enemy.player.transform.position, enemy.Vision);
                Debug.DrawRay(enemy.Head.transform.position, enemy.player.transform.position * enemy.Vision);
                if (Attantion.collider.tag == "Player")
                {
                    enemy.piece = false;
                }
            
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
