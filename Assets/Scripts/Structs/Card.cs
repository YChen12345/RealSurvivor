using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Card
{
    public int id;
    public int kind;
    public int rare;
    public int cost;
    public Weapon weapon;
    public Item item;
    public Scroll scroll;

    public void Init()
    {
        id = 0;
        kind = 0;
        rare = 0;
        cost = 0;
    }
}
