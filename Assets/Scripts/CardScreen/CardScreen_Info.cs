using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
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
    public Config_D_enemy d_enemy;
    public Config_D_card d_card;
    public Config_D_hero d_hero;
    public Config_D_cardpool d_cardpool;
    public Config_D_weapon d_weapon;
    public Config_D_skill d_skill;
    void Awake()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        //hd = uf.LoadStructFromJson<HeroData>("Data/HeroData");
        LoadConfig();
        cardScreen.Init();
        cardScreen.boss = levels.levels[bd.wave].bossid;
        cardScreen.emylist = new List<int>(levels.levels[bd.wave].enemyid);
        cardScreen.remainCard = new List<int>(bd.cardList_Total.OrderBy(x => Random.value).ToList());
        cardScreen.remainCard_weapon = new List<int>(bd.cardList_Weapon);
        cardScreen.remainCard_item = new List<int>(bd.cardList_Item);
        cardScreen.remainCard_scroll = new List<int>(bd.cardList_Scroll);
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
        d_enemy = uf.LoadStructFromJson<Config_D_enemy>("Config/D/Config_D_enemy");
        d_card = uf.LoadStructFromJson<Config_D_card>("Config/D/Config_D_card");
        d_hero = uf.LoadStructFromJson<Config_D_hero>("Config/D/Config_D_hero");
        d_cardpool = uf.LoadStructFromJson<Config_D_cardpool>("Config/D/Config_D_cardpool");
        d_weapon = uf.LoadStructFromJson<Config_D_weapon>("Config/D/Config_D_weapon");
        d_skill = uf.LoadStructFromJson<Config_D_skill>("Config/D/Config_D_skill");
    }
    public void ComputeHeroFeature()
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
