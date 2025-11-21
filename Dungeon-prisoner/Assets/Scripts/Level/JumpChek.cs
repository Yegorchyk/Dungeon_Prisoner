using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChek : MonoBehaviour
{
    public GameObject FatherObj;
    public GameObject Player;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Player.GetComponent<Player>().isJumped = false;
    }
}
