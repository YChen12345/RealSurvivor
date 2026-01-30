using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class HeroChoose_Info : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public PlayerData pd;
    public BattleData bd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
    }
}
