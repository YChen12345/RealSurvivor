using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Config_Skill
{
    public List<Skill> skills;

    public void Init()
    {
        skills = new List<Skill>();
    }
}
