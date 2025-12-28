using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Card
{
    public int id;
    public int kind;
    public int rare;
    public int cost;
    public WeaponData weapondata;
    public ItemData itemdata;
    public ScrollData scrolldata;

    public void Init()
    {
        id = 0;
        kind = 0;
        rare = 0;
        cost = 0;
    }
}
