using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Market
{
    public List<int> draw_cost;
    public List<int> card_cost;
    public List<int> stuff_cost;
    public List<int> draw_unlockCost;

    public void Init()
    {
        draw_cost = new List<int>(){0,0,0,0,0 };
        card_cost = new List<int>(){ 0, 0, 0, 0};
        stuff_cost = new List<int>() { 0, 0, 0 };
        draw_unlockCost = new List<int>() {0,0,0,0,0 };
    }
}
