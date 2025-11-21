using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject Player;

    public List<SpriteRenderer> itms = new List<SpriteRenderer>();
    public List<GameObject> wpns;

    public GameObject camera;
    void Start()
    {
        Player = GameObject.Find("Player");
        wpns = Player.GetComponent<Inventory>().Weapons;
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
           //Debug.Log(x);
            //itms[x].sprite = Player.GetComponent<Inventory>().Weapons[x].GetComponent<SpriteRenderer>().sprite;
       
      

        
        GameObject.DontDestroyOnLoad(gameObject);
       // Debug.Log(Player.GetComponent<Inventory>().Weapons[1].GetComponent<SpriteRenderer>().sprite);
       
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if(Time.timeScale > 0)
            {
              
                Time.timeScale = 0;
                Buttons.SetActive(true);




            }
            else
            {
                Resume();
            }
          
        }




       
        


    }

    public void Sprites()
    {
        for(int x = 0; x<=itms.Count; x++)
        {
            Debug.Log(x);
            itms[x].sprite = Player.GetComponent<Inventory>().Weapons[x].GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Buttons.SetActive(false);
    }

    public void toMenu()
    {
       
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
        Destroy(Player);
        Destroy(camera);
        Destroy(gameObject);

    }

    public void Restart()
    {
       
        Time.timeScale = 1;
        SceneManager.LoadScene("Kanakisation");

        Destroy(Player);
        Destroy(camera);
        Destroy(gameObject);

    }

    public void Exit()
    {
        Application.Quit();
    }
}
