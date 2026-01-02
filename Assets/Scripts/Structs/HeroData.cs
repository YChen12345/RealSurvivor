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
        blood += c.item.blood;
        mana += c.item.mana;
        speed += c.item.speed;
        defence += c.item.defence;
        atkspeed += c.item.atkspeed;
        phurt += c.item.phurt;
        mhurt += c.item.mhurt;
        trans += c.item.trans;
        critical += c.item.critical;
        dodge += c.item.dodge;
        extramoney += c.item.extramoney;
        extraexp += c.item.extraexp;
        repel += c.item.repel;
        extrahurt += c.item.extrahurt;
    }
    public void PlusScroll(Card c)
    {
        blood += c.scroll.blood;
        mana += c.scroll.mana;
        speed += c.scroll.speed;
        defence += c.scroll.defence;
        atkspeed += c.scroll.atkspeed;
        phurt += c.scroll.phurt;
        mhurt += c.scroll.mhurt;
        trans += c.scroll.trans;
        critical += c.scroll.critical;
        dodge += c.scroll.dodge;
        extramoney += c.scroll.extramoney;
        extraexp += c.scroll.extraexp;
        repel += c.scroll.repel;
        extrahurt += c.scroll.extrahurt;
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
