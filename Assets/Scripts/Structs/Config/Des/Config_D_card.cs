using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_D_card
{
    public List<CardDescription> cardDesList;
    public void Init()
    {
        cardDesList = new List<CardDescription>();
    }
}
