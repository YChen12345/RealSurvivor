using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Enemy
{
    public int blood;
    public float speed;
    public int defence;
    public float atkgap;
    public int attack;
    public int trans;
    public int mode_move;
    public int mode_atk;
    public float atkdistance;
    public int dropid;
    public void Init()
    {
        blood = 3;
        speed = 1;
        defence = 3;
        atkgap = 1;
        attack = 0;
        trans = 0;
        mode_move = 0;
        mode_atk = 0;
        atkdistance = 3;
        dropid = 1;
    }
}
