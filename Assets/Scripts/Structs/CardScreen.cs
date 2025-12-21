using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct CardScreen
{
    public List<int> handCard;
    public List<int> emylist;
    public int boss;
    public int cardUsed_thisRound;

    public void Init()
    {
        handCard = new List<int>();
        emylist = new List<int>();
        boss = 0;
        cardUsed_thisRound = 0;
    }
}
