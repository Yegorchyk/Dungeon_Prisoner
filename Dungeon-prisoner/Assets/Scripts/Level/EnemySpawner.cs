using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enm = new List<GameObject>();
    public int num;

    public Transform PointLeft, PointRight;
    [SerializeField] private GameObject enmSpawned;
    void Start()
    {
        if(PointLeft.position.x >= transform.position.x)
        {
            transform.rotation = new Quaternion(0,  0, 0, 180);
        }
       
        for (int x = 0; x <= Enm.Count; x++)
        {
            enmSpawned = Instantiate(Enm[x], transform.position, new Quaternion(0, 0, 0, 0));
            enmSpawned.GetComponent<Enemy>().pointLeft = PointLeft;
            enmSpawned.GetComponent<Enemy>().pointRight = PointRight;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
