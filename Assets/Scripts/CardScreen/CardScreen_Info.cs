using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class CardScreen_Info : MonoBehaviour
{
    IUF uf;
    public BattleData bd;
    public HeroData hd;
    public CardScreen cardScreen;

    public Config_Enemy enemies;
    public Config_Weapon weapons;
    public Config_Card cards;
    public Config_Hero heros;
    public Config_Level levels;
    public Config_Drop drops;
    public Config_Skill skills;
    void Awake()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        //hd = uf.LoadStructFromJson<HeroData>("Data/HeroData");
        cardScreen.Init();
        cardScreen.remainCard = new List<int>(bd.cardList_Total);
        cardScreen.remainCard_weapon = new List<int>(bd.cardList_Weapon);
        cardScreen.remainCard_item = new List<int>(bd.cardList_Item);
        cardScreen.remainCard_scroll = new List<int>(bd.cardList_Scroll);
        LoadConfig();
        ComputeHeroFeature();
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
    void ComputeHeroFeature()
    {
        hd = heros.heros[bd.heroID];
        for (int i = 0; i < bd.ItemCardList.Count; i++)
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
}
