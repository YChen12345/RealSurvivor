using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_MarketCardPossiblity
{
    public List<MarketPossiblity> possiblity;
    public void Init()
    {
        possiblity = new List<MarketPossiblity>();
    }
}
