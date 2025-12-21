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
        attack = 1;
        trans = 1;
        distance = 3;
        speed = 6;
        across = 0;
        range = 0.2f;
        atkgap = 1;
        lasttime = 0;
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
