using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct CardScreen
{
    public List<int> remainCard;
    public List<int> remainCard_weapon;
    public List<int> remainCard_item;
    public List<int> remainCard_scroll;
    public List<int> handCard;
    public List<int> emylist;
    public int boss;
    public int cardUsed_thisRound;

    public void Init()
    {
        remainCard = new List<int>();
        remainCard_weapon = new List<int>();
        remainCard_item = new List<int>();
        remainCard_scroll = new List<int>();
        handCard = new List<int>();
        emylist = new List<int>() { 0, 0, 0 };
        boss = 0;
        cardUsed_thisRound = 0;
    }
}
