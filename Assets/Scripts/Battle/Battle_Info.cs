using System.Collections.Generic;
using UnityEngine;

public class Battle_Info : MonoBehaviour
{
    IUF uf;
    public Config_Enemy enemies;
    public Config_Weapon weapons;
    public Config_Card cards;
    public Config_Hero heros;
    public Config_Level levels;
    public Config_Drop drops;
    public Config_Skill skills;

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
    public int dead;
    public int settlement_state;
    void Awake()
    {
        uf = new Functions();
        clock = 20;
        totaltime = 0;
        generation_t = 0;
        //Save();
        LoadConfig();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");     
        bd.NewBattle();
        ComputeHeroFeature();
        bd.player = GameObject.Find("Player");
        map_width = 10.35f * 2;
        map_height = 7.54f * 2;
        maxEmyInScreen = 10;
        
    }
    void ComputeHeroFeature()
    {
        hd = heros.heros[bd.heroID];
        for(int i = 0; i < bd.ItemCardList.Count; i++)
        {
            hd.PlusItem(cards.cards[bd.ItemCardList[i]]);
        }
        for (int i = 0; i < bd.ScrollCardList.Count; i++)
        {
            hd.PlusItem(cards.cards[bd.ScrollCardList[i]]);
        }
        for (int i = 0; i < bd.SkillList.Count; i++)
        {
            hd.PlusSkill(skills.skills[bd.SkillList[i]]);
        }
    }
    void LoadConfig()
    {
        enemies = uf.LoadStructFromJson<Config_Enemy>("Config/Config_Enemy");
        weapons = uf.LoadStructFromJson<Config_Weapon>("Config/Config_Weapon");
        cards = uf.LoadStructFromJson<Config_Card>("Config/Config_Card");
        heros = uf.LoadStructFromJson<Config_Hero>("Config/Config_Hero");
        levels = uf.LoadStructFromJson<Config_Level>("Config/Config_Level");
        drops = uf.LoadStructFromJson<Config_Drop>("Config/Config_Drop");
        skills = uf.LoadStructFromJson<Config_Skill>("Config/Config_Skill");
    }
    void Save()
    {
        enemies.Init();
        weapons.Init();
        cards.Init();
        heros.Init();
        levels.Init();
        drops.Init();
        skills.Init();
        HeroData h = new HeroData();
        Level l = new Level();
        l.Init();
        Drop d = new Drop();
        Skill s = new Skill();
        heros.heros.Add(h);
        heros.heros.Add(h);
        levels.levels.Add(l);
        levels.levels.Add(l);
        drops.drops.Add(d);
        drops.drops.Add(d);
        skills.skills.Add(s);
        skills.skills.Add(s);
        //uf.SaveStructToJson<Config_Enemy>(enemies, "Config/Config_Enemy");
        //uf.SaveStructToJson<Config_Weapon>(weapons, "Config/Config_Weapon");
        //uf.SaveStructToJson<Config_Card>(cards, "Config/Config_Card");
        //uf.SaveStructToJson<Config_Hero>(heros, "Config/Config_Hero");
        //uf.SaveStructToJson<Config_Level>(levels, "Config/Config_Level");
        //uf.SaveStructToJson<Config_Drop>(drops, "Config/Config_Drop");
        uf.SaveStructToJson<Config_Skill>(skills, "Config/Config_Skill");
    }
}
