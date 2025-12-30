using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_D_skill
{
    public List<SkillDescription> skillDesList;
    public void Init()
    {
        skillDesList = new List<SkillDescription>();
    }
}
