using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Weapon
{
    public int id;
    public float atkgap;
    public float triggerdistance;
    public int mode;
    public int basichurt;
    public float hurt_p;
    public float hurt_m;
    public int basictrans;
    public float trans_t;
    public float speed;
    public float flydistance;
    public float lasttime;
    public float hurtgap;
    public float atkrange;
    public int maxaim;
    public int maxcross;
    public int repel;

    public void Init()
    {
        atkgap = 1;
        triggerdistance = 5;
        mode = 0;
        basichurt=0;
        hurt_p=0;
        hurt_m=0;
        basictrans = 0;
        trans_t = 0;
        speed = 0;
        flydistance = 5;
        lasttime = 0;
        hurtgap = 1;
        atkrange = 0;
        maxaim = 0;
        maxcross = 0;
        repel = 0;
    }
}
