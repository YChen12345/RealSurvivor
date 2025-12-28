using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Config_Card
{
    public List<Card> cards;
    public void Init()
    {
        cards = new List<Card>();
    }
}
