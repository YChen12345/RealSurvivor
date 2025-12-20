using UnityEngine;
[System.Serializable]
public struct PlayerBullet
{
    public int attack;
    public int trans;
    public float distance;
    public float speed;
    public int across;
    public float range;
    public float atkgap;
    public float lasttime;
    public int maxaim;

    public void Init()
    {
        attack = 0;
        trans = 0;
        distance = 1;
        speed = 1;
        across = 0;
        range = 1;
        atkgap = 1;
        lasttime = 1;
        maxaim = 1;
    }
    public void Set(WeaponData wd)
    {
        attack = wd.hurt;
        trans = wd.trans;
        distance = wd.flydistance;
        speed = wd.speed;
        across = wd.maxcross;
        range = wd.atkrange;
        atkgap = wd.atkgap;
        lasttime = wd.lasttime;
        maxaim = wd.maxaim;
    }
}
