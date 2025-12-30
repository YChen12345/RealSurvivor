using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_D_cardpool
{
    public List<CardPoolDescription> cardPoolDesList;
    public void Init()
    {
        cardPoolDesList = new List<CardPoolDescription>();
    }
}
