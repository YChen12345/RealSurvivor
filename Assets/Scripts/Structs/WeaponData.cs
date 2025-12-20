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
    }
}