using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image hpBar;
    public GameObject player;

  
    public Image adrBar;

  
    public Image mpBar;

    public Image xpBar;


    public GameObject BossHpBar;
    public GameObject Boss;

    public string name;
    void Start()
    {
      
        if(player == null)
        {
            player = GameObject.Find(name);
        }
       
 
    }

    // Update is called once per frame
    void Update()
    {
       
        hpBar.fillAmount = player.GetComponent<Stats>().hp / player.GetComponent<Stats>().maxHp;

        adrBar.fillAmount = player.GetComponent<Stats>().Adrenalin / player.GetComponent<Stats>().maxAdrenalin;
        mpBar.fillAmount = player.GetComponent<Stats>().mp / player.GetComponent<Stats>().maxMp;


        xpBar.fillAmount = player.GetComponent<PlayerMetaProgress>().Expirience / player.GetComponent<PlayerMetaProgress>().maxExpiriens;

        BossHpBar.GetComponent<Image>().fillAmount = Boss.GetComponent<Stats>().hp / Boss.GetComponent<Stats>().maxHp;

      
    }
}
