using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public DataBase data;
    public int id, ID;
    public Camera cam;
    public GameObject player;
    public Stats st;

   
    void Start()
    {
        player = GameObject.Find("Player");
        st = GetComponent<Stats>();

        cam = Camera.main;
        data = Camera.main.GetComponent<DataBase>();

       
        
            id = Random.Range(0, data.itm.Count);
            ID = id;
            GetComponent<SpriteRenderer>().sprite = data.itm[id].img;

       
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
        // Debug.Log(player.GetComponent<Stats>().maxDef);
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 1 && Input.GetKeyDown(("f")))
        {
            // Debug.Log( data.itm[id].Spell);
            if(data.itm[id].type == 2)
            {
                player.GetComponent<Inventory>().Weapons[2] = data.itm[id].Spell;
                player.GetComponent<Stats>().MagForm = data.itm[id].st.MagForm;
                player.GetComponent<Stats>().ChosenElement = data.itm[id].ChosenElement;
            }
           

            player.GetComponent<Inventory>().Weapons[data.itm[id].type].GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            player.GetComponent<Inventory>().WeapSprt[data.itm[id].type].sprite = gameObject.GetComponent<SpriteRenderer>().sprite;       
            var color = player.GetComponent<Inventory>().WeapSprt[data.itm[id].type].GetComponent<Image>().color;
            color.a = 1;
            color.a = Mathf.Clamp(color.a, 0, 1);
            player.GetComponent<Inventory>().WeapSprt[data.itm[id].type].GetComponent<Image>().color = color;
            Debug.Log(player.GetComponent<Inventory>().WeapSprt[data.itm[id].type].GetComponent<Image>().color.a);

            ItmStatsGiving(data.itm[id].type);
       




                Zamina();
            
           


           // Destroy(gameObject);
        }

        //Debug.Log(player.GetComponent<Inventory>().id[data.itm[id].type - 1] - 1);
    }

    private void ItmStatsGiving(int tipe)
    {
        switch (tipe)
        {
            case 1:
                player.GetComponent<Stats>().maxDammage = data.itm[id].st.dammage;
                player.GetComponent<Stats>().dammage = player.GetComponent<Stats>().maxDammage;
               player.GetComponent<Player>().ult = data.itm[id].Ult;

                player.GetComponent<PlayerAudio>().hit = data.itm[id].sound;
                break;

            case 2:
                player.GetComponent<Stats>().maxMagDammage = data.itm[id].st.maxMagDammage;
                player.GetComponent<Stats>().magdammage = player.GetComponent<Stats>().maxMagDammage;

               
                break;

            case 3:

                player.GetComponent<Stats>().maxHp = data.itm[id].st.maxHp;

                player.GetComponent<Stats>().maxDef -= player.GetComponent<Inventory>().plusDefBody;
                player.GetComponent<Stats>().def -= player.GetComponent<Inventory>().plusDefBody;

                player.GetComponent<Stats>().maxDef += data.itm[id].st.maxDef;
                player.GetComponent<Inventory>().plusDefBody = player.GetComponent<Stats>().maxDef - player.GetComponent<Stats>().def;
                player.GetComponent<Stats>().def = player.GetComponent<Stats>().maxDef;
                break;

            case 4:
                player.GetComponent<Stats>().maxDef-= player.GetComponent<Inventory>().plusDefHead;
                player.GetComponent<Stats>().def -= player.GetComponent<Inventory>().plusDefHead;

                player.GetComponent<Stats>().maxDef += data.itm[id].st.maxDef;
                player.GetComponent<Inventory>().plusDefHead = player.GetComponent<Stats>().maxDef - player.GetComponent<Stats>().def;
                player.GetComponent<Stats>().def = player.GetComponent<Stats>().maxDef;
                break;
        }
    }

    [SerializeField] private GameObject lastItm;
    private void Zamina()
    {
        /*
       lastItm = Instantiate(gameObject, transform.position, Quaternion.identity);

        player.GetComponent<Inventory>().id[data.itm[id].type] = id;
        lastItm.GetComponent<ItemScript>().norandom = true;
        lastItm.GetComponent<ItemScript>().id = player.GetComponent<Inventory>().id[data.itm[id].type - 1];
        lastItm.GetComponent<SpriteRenderer>().sprite = data.itm[player.GetComponent<Inventory>().id[data.itm[id].type - 1]].img;*/

      

        if (player.GetComponent<Inventory>().id[data.itm[id].type -1] != -1)
        {
            id = player.GetComponent<Inventory>().id[data.itm[id].type-1];
            GetComponent<SpriteRenderer>().sprite = data.itm[id].img;
           // Debug.Log(id);
            player.GetComponent<Inventory>().id[data.itm[id].type -1] = ID;
            //Debug.Log(player.GetComponent<Inventory>().id[data.itm[id].type - 1]);
            ID = id;
            //Debug.Log(ID);
          

            

            


        }
        else
        {
            player.GetComponent<Inventory>().id[data.itm[id].type -1] = id;
            Destroy(gameObject);
        }
        
          
           
        
        
    }
}


