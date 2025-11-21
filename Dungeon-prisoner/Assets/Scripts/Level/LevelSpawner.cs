using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public CameraMove cam;
    public List<GameObject> lvs = new List<GameObject>();
    public int side;
    [SerializeField] private GameObject Child;
    [SerializeField] private GameObject Father;
    [SerializeField] private GameObject End;
    [SerializeField] private GameObject Escape, FindEscape;
    [SerializeField] private bool noSpawn;
    [SerializeField] private bool esc;


    void Start()
    {
        FindEscape = GameObject.Find("Escape");
       
      

        cam = Camera.main.GetComponent<CameraMove>();
        if(cam.lvCount <= cam.lvRange && noSpawn == false && esc == false)
        {
            Child = Instantiate(lvs[Random.Range(0, lvs.Count)], transform.position, transform.rotation);
            cam.lvCount += 1;
           
           
            /*if(RoomCheck.collider.tag != null)
            {
                Child.SetActive(false);
            }
            else
            {
                Child.SetActive(true);
            }*/
            



        }
        else if(FindEscape != null )
        {
            Instantiate(End, transform.position, transform.rotation);
         
        }

        else if (FindEscape == null )
        {
            Instantiate(Escape, transform.position, transform.rotation);
        }





    }

    public float xPoz;
    public GameObject player;
    public void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x + 1, transform.position.y), transform.right * 50, Color.red);

      

        RaycastHit2D RoomCheck = Physics2D.Raycast(new Vector2(transform.position.x + xPoz, transform.position.y), transform.right, 20);
       // Debug.Log(RoomCheck.collider.tag);
        if (RoomCheck.collider.tag == "Ground" || RoomCheck.collider.tag == "Walls")
        {
            Child.SetActive(false);
            noSpawn = true;
        }
        else
        {
            noSpawn = false;
        }


        if(Vector2.Distance(gameObject.transform.position, player.transform.position) < 5)
        {
            Child.SetActive(true);
        }
        else
        {
            Child.SetActive(false);
        }


    }
   

    public void OnTriggerEnter2D(Collider2D collision)
    {

      /*  if (collision.gameObject.tag == "Room" /*&& Child.GetComponent<Rigidbody2D>().name != Child.name)
        {
            // Destroy(Child);
            Father.SetActive(false);
            Child.SetActive(false);
        }*/

        Debug.Log(gameObject.tag);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        Debug.Log(gameObject.tag);
    }
}
