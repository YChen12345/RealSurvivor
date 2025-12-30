using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_D_hero
{
    public List<HeroDescription> heroDesList;
    public void Init()
    {
        heroDesList = new List<HeroDescription>();
    }
}
