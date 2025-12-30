using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_Boss
{
    public List<Enemy> bossList;
    public void Init()
    {
        bossList = new List<Enemy>();
    }
}
