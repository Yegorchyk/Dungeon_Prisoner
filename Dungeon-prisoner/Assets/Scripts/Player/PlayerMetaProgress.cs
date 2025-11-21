using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetaProgress : MonoBehaviour 
{
    
    public float Expirience, maxExpiriens;
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        Expirience = PlayerPrefs.GetFloat("Expirience");

        if(Expirience >= maxExpiriens)
        {
            PlayerPrefs.SetFloat("Expirience", 0);
            PlayerPrefs.SetFloat("SkillPoints", PlayerPrefs.GetFloat("SkillPoints") + 1);
        }
        //Debug.Log(PlayerPrefs.GetFloat("Expirience"));
    }
}
