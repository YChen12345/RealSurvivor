using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Level
{
    public int id;
    public int difficulty;
    public float clock;
    public int maxEmyInScreen;
    public float generateGapClock;
    public int bossid;
    public List<int> enemyid;
    public List<int> enemynum;

    public void Init()
    {
        enemyid = new List<int>();
        enemynum = new List<int>();
    }
}
