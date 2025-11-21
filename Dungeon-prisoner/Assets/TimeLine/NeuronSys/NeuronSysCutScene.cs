using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Playables;

public class NeuronSysCutScene : MonoBehaviour
{

    [SerializeField] private Bounds bound;

    public GameObject Player;
    private PlayableDirector dir;

    [SerializeField] private GameObject Interface, SkillMenu;
    private void Start()
    {
        Player = GameObject.Find("Player");
        Interface = GameObject.Find("Interface");
        SkillMenu = GameObject.Find("SkillMenu");
        SkillMenu.SetActive(false);

        bound.center = transform.position;
        bound.extents = transform.localScale;
        dir = GetComponentInChildren<PlayableDirector>();
    }
    // Update is called once per frame
    void Update()
    {
        if (bound.Contains(Player.transform.position) && Input.GetKeyDown("f"))
        {
            dir.Play();
            Player.SetActive(false);
        }
    }

   
    public void CanvasOff()
    {
        Interface.SetActive(false);
        Time.timeScale = 0;
        SkillMenu.SetActive(true);
    }
}
