using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{

    public GameObject player;
    public string escname;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < 1)
        {
            if (Input.GetKey("f"))
            {
                SceneManager.LoadScene(escname);
               // Camera.main.GetComponent<CameraMove>().playerStartPos = GameObject.Find("PlayerStartPos").transform.transform;
            }
        }
    }
}
