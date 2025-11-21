using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float speed;
    public float rotY;
    public float rotateSpeed;
    void Start()
    {
        //rotY = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        //transform.Rotate(0,  0, 1f * Time.deltaTime * -rotateSpeed);
        if(rotY >= 1)
        {
            rotY = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
        }
    }
}
