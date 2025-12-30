using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Config_D_enemy
{
    public List<EnemyDescription> enemyDesList;
    public void Init()
    {
        enemyDesList = new List<EnemyDescription>();
    }
}
