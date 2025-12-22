using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct CardScreen
{
    public List<int> remainCard;
    public List<int> handCard;
    public List<int> emylist;
    public int boss;
    public int cardUsed_thisRound;

    public void Init()
    {
        remainCard = new List<int>();
        handCard = new List<int>();
        emylist = new List<int>() { 0, 0, 0 };
        boss = 0;
        cardUsed_thisRound = 0;
    }
}
