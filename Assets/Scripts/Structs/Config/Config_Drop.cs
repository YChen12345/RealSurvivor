using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Config_Drop
{
    public List<Drop> drops;
    public void Init()
    {
        drops = new List<Drop>();
    }
}
