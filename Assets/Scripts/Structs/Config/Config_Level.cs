using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Config_Level
{
    public List<Level> levels;

    public void Init()
    {
        levels = new List<Level>();
    }
}
