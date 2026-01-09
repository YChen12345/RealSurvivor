using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Config_CardPoolPossibility
{
    public List<MarketPossiblity> possiblity;
    public void Init()
    {
        possiblity = new List<MarketPossiblity>();
    }
}
