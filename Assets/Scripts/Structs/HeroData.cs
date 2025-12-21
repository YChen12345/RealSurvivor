using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct HeroData
{
    public int blood;
    public int mana;
    public float speed;
    public int defence;   
    public float atkspeed;
    public int phurt;
    public int mhurt;
    public int trans;
    public float critical;
    public float dodge;
    public int extramoney;
    public int extraexp;
    public int repel;
    public float extrahurt;

    public HeroData(HeroData hd)
    {
        blood = hd.blood;
        mana = hd.mana;
        speed = hd.speed;
        defence = hd.defence;
        atkspeed = hd.atkspeed;
        phurt = hd.phurt;
        mhurt = hd.mhurt;
        trans = hd.trans;
        critical = hd.critical;
        dodge = hd.dodge;
        extramoney = hd.extramoney;
        extraexp = hd.extraexp;
        repel = hd.repel;
        extrahurt = hd.extrahurt;
    }
    public void init()
    {
        blood = 10;
        mana = 0;
        speed = 3;
        defence = 3;
        atkspeed = 0;
        phurt = 0;
        mhurt = 0;
        trans = 0;
        critical = 0;
        dodge = 0;
        extramoney = 0;
        extraexp = 0;
        repel = 0;
        extrahurt = 0;
    }
}
