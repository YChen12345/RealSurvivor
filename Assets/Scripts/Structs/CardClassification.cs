using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct CardClassification
{
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
