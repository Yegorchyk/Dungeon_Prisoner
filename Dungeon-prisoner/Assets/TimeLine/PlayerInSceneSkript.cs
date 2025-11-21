using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInSceneSkript : MonoBehaviour
{

    public GameObject Player;

    private GameObject Cam;
    [SerializeField] private Camera cutSceneCam;
    [SerializeField] private Transform playerPos;

    private bool invStart;
    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera"); 
      
        Player = GameObject.FindGameObjectWithTag("Player");

       
    }

    // Update is called once per frame
    void Update()
    {
       
       

    }



    public void PlayerBack()
    {
        Player.SetActive(true);
        Cam.SetActive(true);

        if(Vector2.Distance(Cam.transform.position, Player.transform.position) > 1)
        {
            Cam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Cam.transform.position.z);
        }
       
        GetComponent<Enemy>().piece = false;
        Player.transform.position = playerPos.position;
         invStart = true;
}

   
    public void PlInv()
    {
        // GetComponent<Inventory>().Weapons.Count
        if(invStart == true)
        {
            for (int x = 0; x <= 5; x++)
            {
                Debug.Log(x);
                if (GetComponent<Inventory>().Weapons[x] != null)
                {
                    GetComponent<Inventory>().Weapons[x].GetComponent<SpriteRenderer>().sprite = Player.GetComponent<Inventory>().Weapons[x].GetComponent<SpriteRenderer>().sprite;
                }
                Player.SetActive(false);
                Cam.SetActive(false);
                x = 0;
                invStart = false;

            }
        }

        //Debug.Log(invStart);

      

    }
}
