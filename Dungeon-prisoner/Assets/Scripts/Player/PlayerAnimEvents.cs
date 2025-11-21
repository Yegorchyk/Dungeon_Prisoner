using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    [SerializeField] private GameObject playerAtk;
    public GameObject DamCircle;

    [SerializeField] private GameObject Player;

    public void NoMove()
    {
        GetComponent<Player>().Ismoving = false;
    }
    public void Hit()
    {
        DamCircle.SetActive(true);
        DamCircle.GetComponent<DamageTrig>().damage = GetComponent<Stats>().dammage;
        DamCircle.transform.position = playerAtk.transform.position;
    }

    public void NoHit()
    {
        DamCircle.SetActive(false);
        Player.GetComponent<Stats>().dammage = Player.GetComponent<Stats>().maxDammage;
    }

    [SerializeField] private GameObject newPos;
    [SerializeField] private Transform PlayerBodyPos;
    public void OnEdje()
    {
        //Instantiate(newPos, PlayerBodyPos.position, Quaternion.identity);
        Player.transform.position = new Vector3( newPos.transform.position.x, newPos.transform.position.y, Player.transform.position.z);
        Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        Player.GetComponent<Rigidbody2D>().simulated = true;
        Player.GetComponent<Player>().Ismoving = true;
    }

    public void IrzaviySwordHit()
    {
        DamCircle.SetActive(true);
        Player.GetComponent<Stats>().dammage *= 2f;
    }
}
