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
    public void Plus(HeroData hd)
    {
        blood += hd.blood;
        mana += hd.mana;
        speed += hd.speed;
        defence += hd.defence;
        atkspeed += hd.atkspeed;
        phurt += hd.phurt;
        mhurt += hd.mhurt;
        trans += hd.trans;
        critical += hd.critical;
        dodge += hd.dodge;
        extramoney += hd.extramoney;
        extraexp += hd.extraexp;
        repel += hd.repel;
        extrahurt += hd.extrahurt;
    }
    public void PlusItem(Card c)
    {
        blood += c.itemdata.blood;
        mana += c.itemdata.mana;
        speed += c.itemdata.speed;
        defence += c.itemdata.defence;
        atkspeed += c.itemdata.atkspeed;
        phurt += c.itemdata.phurt;
        mhurt += c.itemdata.mhurt;
        trans += c.itemdata.trans;
        critical += c.itemdata.critical;
        dodge += c.itemdata.dodge;
        extramoney += c.itemdata.extramoney;
        extraexp += c.itemdata.extraexp;
        repel += c.itemdata.repel;
        extrahurt += c.itemdata.extrahurt;
    }
    public void PlusScroll(Card c)
    {
        blood += c.scrolldata.blood;
        mana += c.scrolldata.mana;
        speed += c.scrolldata.speed;
        defence += c.scrolldata.defence;
        atkspeed += c.scrolldata.atkspeed;
        phurt += c.scrolldata.phurt;
        mhurt += c.scrolldata.mhurt;
        trans += c.scrolldata.trans;
        critical += c.scrolldata.critical;
        dodge += c.scrolldata.dodge;
        extramoney += c.scrolldata.extramoney;
        extraexp += c.scrolldata.extraexp;
        repel += c.scrolldata.repel;
        extrahurt += c.scrolldata.extrahurt;
    }
    public void PlusSkill(Skill s)
    {
        blood += s.blood;
        mana += s.mana;
        speed += s.speed;
        defence += s.defence;
        atkspeed += s.atkspeed;
        phurt += s.phurt;
        mhurt += s.mhurt;
        trans += s.trans;
        critical += s.critical;
        dodge += s.dodge;
        extramoney += s.extramoney;
        extraexp += s.extraexp;
        repel += s.repel;
        extrahurt += s.extrahurt;
    }
}
