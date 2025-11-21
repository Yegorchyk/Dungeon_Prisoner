using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 51)]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public Sprite img;
    public int type; //1-зброя, 2-магія, 3-броня, 4-шолом, 5-додаткове

    public AudioClip sound;
    public GameObject Spell;
    public int ChosenElement;
    public string Ult;
    public MainStats st = new MainStats();


}

[System.Serializable]

public struct MainStats
{
    public float hp;
    public float maxHp;

    public float def;
    public float maxDef;

    public float mpDef, maxmpDef;

    public float Adrenalin, maxAdrenalin;
    public float mp, maxMp;

    public float dammage, magdammage;
    public float maxDammage, maxMagDammage;

    public int MagForm; //форма закляття

    public float mpEffectProbability; // Ймовірність крит ефекта магії
    public int mpEffect; // Який саме ефект накладений 1-вогонь, 2-вода, 3-повітря, 4-земля.

    public int EffectTIme, maxEffectTime; //періодичність ефекту.
    public int EffectTimeScale, maxEffectTimeScale;

    public float speed, maxSpeed;

    public int ChosenElement; // обрана стихія закляття

    public bool takeDammage;

}
