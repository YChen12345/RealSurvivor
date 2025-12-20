using System;
using UnityEngine;

public class Win_Victory : MonoBehaviour
{
    IUF uf;
    BattleData bd;
    PlayerData pd;
    int hid;
    int wid;
    int lid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        PlayerPrefs.SetInt("State", 0);
        hid = bd.heroID;
        wid = bd.weaponID;
        lid = bd.levelID;
        Reward();
        uf.SaveStructToJson<PlayerData>(pd, "Data/PlayerData");
    }

    void Reward()
    {
        pd.money += 666;
        if (pd.levelList[hid]<lid + 1)
        {
            pd.levelList[hid] = lid + 1;
        }
    }
}
