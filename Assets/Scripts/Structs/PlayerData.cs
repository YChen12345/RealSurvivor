using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct PlayerData
{
    public int money;
    public List<int> heroList;
    public List<int> weaponList;
    public List<int> levelList;

    public void Init()
    {
        money = 360;
        heroList = new List<int>() { 0 };
        weaponList = new List<int>() { 0,3,6,9 };
        levelList = new List<int>() { 0,0,0,0 };
    }
}
