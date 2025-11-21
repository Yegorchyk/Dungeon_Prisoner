using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KingOfRatsCutScene : MonoBehaviour
{

    [SerializeField] private PlayableDirector dir;
    [SerializeField] private GameObject king;
    [SerializeField] private PlayableGraph gr ;

    private Playable pl;

    private GameObject Player;
    [SerializeField] private GameObject PlayerinCutScene;
    private Camera cam;
    private GameObject Cam;
   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                      
            dir.Play();

            Cam.SetActive(false);
           

            // Debug.Log(dir.playOnAwake);
        }
    }
    void Start()
    {
        dir = GetComponent<PlayableDirector>();
        gr = GetComponent<PlayableDirector>().playableGraph;

        Player = GameObject.Find("Player");
       
        cam = Camera.main;
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Cam.activeSelf);
        PlayerinCutScene.GetComponent<PlayerInSceneSkript>().Player = Player;

       
        if (gr.IsDone() == true)
        {
            //gr.Stop();
            Debug.Log("IsDone");
        }
    }

   
}
