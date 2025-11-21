using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public bool move;
    public GameObject Player;
    public float speed;

    public float x1, x2, y1, y2;
    public int lvCount, lvRange;

    public Transform playerStartPos;
    public void Start()
    {
        Player = GameObject.Find("Player");
       
    }

    public void Update()
    {
        Moving(false, false, false, false);
        GameObject.DontDestroyOnLoad(gameObject);

    }


    private void Moving( bool moveUp, bool moveRight, bool moveLeft, bool moveDawn)
    {
        if (move == true)
        {
            if (transform.position.x - Player.transform.position.x < x1)
            {

                moveRight = true;
            }
            else
            {
                moveRight = false;
            }
            if (transform.position.x - Player.transform.position.x > x2)
            {
                moveLeft = true;
            }

            else
            {
                moveLeft = false;
            }

            if (transform.position.y - Player.transform.position.y > y1)
            {
                moveDawn = true;
            }
            else
            {
                moveDawn = false;
            }

            if (transform.position.y - Player.transform.position.y < y2)
            {
                moveUp = true;
            }
            else
            {
                moveUp = false;
            }

        }

        if (moveRight == true)
        {

            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if (moveLeft == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);

        }

        if (moveDawn == true)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 20);

        }

        if (moveUp == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 20);

        }
    }
}
