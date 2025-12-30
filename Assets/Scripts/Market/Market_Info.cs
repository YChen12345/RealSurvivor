using NUnit.Framework;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class Market_Info : MonoBehaviour
{
    IUF uf;
    public BattleData bd;
    public HeroData hd;
    public Market market;

    public Config_Enemy enemies;
    public Config_Weapon weapons;
    public Config_Card cards;
    public Config_Hero heros;
    public Config_Level levels;
    public Config_Drop drops;
    public Config_Skill skills;
    public Config_Boss bossList;
    public Config_D_boss d_boss;
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
        market.Init();
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
        bossList = uf.LoadStructFromJson<Config_Boss>("Config/Config_Boss");
        d_boss = uf.LoadStructFromJson<Config_D_boss>("Config/D/Config_D_boss");
        d_enemy = uf.LoadStructFromJson<Config_D_enemy>("Config/D/Config_D_enemy");
        d_card = uf.LoadStructFromJson<Config_D_card>("Config/D/Config_D_card");
        d_hero = uf.LoadStructFromJson<Config_D_hero>("Config/D/Config_D_hero");
        d_cardpool = uf.LoadStructFromJson<Config_D_cardpool>("Config/D/Config_D_cardpool");
        d_weapon = uf.LoadStructFromJson<Config_D_weapon>("Config/D/Config_D_weapon");
        d_skill = uf.LoadStructFromJson<Config_D_skill>("Config/D/Config_D_skill");
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
