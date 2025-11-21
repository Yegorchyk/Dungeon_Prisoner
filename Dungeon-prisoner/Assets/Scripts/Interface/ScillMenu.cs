using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScillMenu : MonoBehaviour
{
    public List<GameObject>  SkillButtons = new List<GameObject>();
    public int[] cost;
    void Start()
    {
        PlayerPrefs.SetInt("SkillPoints", PlayerPrefs.GetInt("SkillPoints") + 1);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < SkillButtons.Count; i++)
        {
            Debug.Log(PlayerPrefs.GetInt(SkillButtons[i].name));
            if (PlayerPrefs.GetInt(SkillButtons[i].name) >= 1)
            {
                SkillButtons[i].SetActive(true);
            }
        }

        
       
        
    }

    public void BuySkill(int id)
    {
        
        
           
            
            
           
            if (PlayerPrefs.GetInt("SkillPoints") >= cost[id] && PlayerPrefs.GetInt(SkillButtons[id].name) != 1)
                {
            Debug.Log(SkillButtons[id]);
            string name = gameObject.name;
                   PlayerPrefs.SetInt(SkillButtons[id].name, 1);
                    Debug.Log(PlayerPrefs.GetInt(SkillButtons[id].name));

                    PlayerPrefs.SetInt("SkillPoints", PlayerPrefs.GetInt("SkillPoints") - cost[id]);
                }
            
        
       
        
    }
    public void ExitSkillMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
