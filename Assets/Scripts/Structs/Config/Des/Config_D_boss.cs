using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_D_boss
{
    public List<BossDescription> bossDesList;
    public void Init()
    {
        bossDesList = new List<BossDescription>();
    }
}
