using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Market
{
    public List<int> draw_cost;//不同品质抽卡基础消耗
    public List<int> card_cost;//不同品质卡牌基础价格
    public List<int> stuff_cost;//扩容道具价格
    public List<int> draw_unlockCost;//抽卡解锁卡池价格
    public int refreshMarketCard_cost;//刷新消耗
    public int discard_cost;
    ////
    public List<int> weaponCard_0;
    public List<int> weaponCard_1;
    public List<int> weaponCard_2;
    public List<int> weaponCard_3;
    public List<int> weaponCard_4;
    public List<int> itemCard_0;
    public List<int> itemCard_1;
    public List<int> itemCard_2;
    public List<int> itemCard_3;
    public List<int> itemCard_4;
    public List<int> scrollCard_0;
    public List<int> scrollCard_1;
    public List<int> scrollCard_2;
    public List<int> scrollCard_3;
    public List<int> scrollCard_4;

    public void Init()
    {
        draw_cost = new List<int>(){10, 20, 30, 50, 80 };
        card_cost = new List<int>(){ 10, 32, 48, 72, 120};
        stuff_cost = new List<int>() {0, 20, 40, 80, 150, 200 };
        draw_unlockCost = new List<int>() {40, 60, 80, 100, 150 };
        refreshMarketCard_cost = 20;
        discard_cost = 25;
        ////
        weaponCard_0 = new List<int>();
        weaponCard_1 = new List<int>();
        weaponCard_2 = new List<int>();
        weaponCard_3 = new List<int>();
        weaponCard_4 = new List<int>();
        itemCard_0 = new List<int>();
        itemCard_1 = new List<int>();
        itemCard_2 = new List<int>();
        itemCard_3 = new List<int>();
        itemCard_4 = new List<int>();
        scrollCard_0 = new List<int>();
        scrollCard_1 = new List<int>();
        scrollCard_2 = new List<int>();
        scrollCard_3 = new List<int>();
        scrollCard_4 = new List<int>();
    }
}
