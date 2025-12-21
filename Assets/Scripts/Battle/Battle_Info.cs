using System.Collections.Generic;
using UnityEngine;

public class Battle_Info : MonoBehaviour
{
    IUF uf;
    public BattleData bd;
    public HeroData hd;
    public float totaltime;
    public float generation_t;
    public float clock;
    public float map_width;
    public float map_height;
    public int maxEmyInScreen;
    public int state;
    public int page_state;
    public int settlement;
    void Awake()
    {
        clock = 20;
        totaltime = 0;
        generation_t = 0;
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        hd = uf.LoadStructFromJson<HeroData>("Data/HeroData");
        bd.player = GameObject.Find("Player");
        map_width = 10.35f * 2;
        map_height = 7.54f * 2;
        maxEmyInScreen = 10;
    }

}
