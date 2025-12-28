using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Config_Weapon
{
    public List<WeaponData> weapons;

    public void Init()
    {
        weapons = new List<WeaponData>();
    }
}
