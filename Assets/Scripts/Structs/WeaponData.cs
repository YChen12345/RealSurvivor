using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct WeaponData
{
    public float atkgap;
    public float triggerdistance;
    public int mode;
    public int hurt;
    public int trans;
    public float speed;
    public float flydistance;
    public float lasttime;
    public float hurtgap;
    public float atkrange;
    public int maxaim;
    public int maxcross;
    public float repel;
    public float critical;

    public void Init()
    {
        atkgap = 1;
        triggerdistance = 5;
        mode = 0;
        hurt = 0;
        trans = 0;
        speed = 0;
        flydistance = 5;
        lasttime = 0;
        hurtgap = 1;
        atkrange = 0;
        maxaim = 0;
        maxcross = 0;
        repel = 0;
        critical = 0;
}
    public void Equal(Weapon wp,HeroData hd)
    {
        atkgap = wp.atkgap;
        triggerdistance = wp.triggerdistance;
        mode = wp.mode;
        hurt = Mathf.Max(1,(int)((wp.basichurt + (wp.hurt_p*hd.phurt) + (wp.hurt_m*hd.mhurt))*(hd.extrahurt+1)));
        trans = (int)((wp.basictrans+(wp.trans_t*hd.trans)) * (hd.extrahurt + 1));
        speed = wp.speed;
        flydistance = wp.flydistance;
        lasttime = wp.lasttime;
        hurtgap = wp.hurtgap;
        atkrange = wp.atkrange;
        maxaim = wp.maxaim;
        maxcross = wp.maxcross;
        repel = wp.repel+hd.repel;
        critical = hd.critical;
    }
}