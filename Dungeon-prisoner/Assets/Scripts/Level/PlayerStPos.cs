using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStPos : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
        Player.transform.position = transform.position;
        Camera.main.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
