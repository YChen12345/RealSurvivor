using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_D_weapon
{
    public List<WeaponDescription> weaponDesList;
    public void Init()
    {
        weaponDesList = new List<WeaponDescription>();
    }
}
