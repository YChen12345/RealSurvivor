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
    public Config_D_enemy d_enemy;
    public Config_D_card d_card;
    public Config_D_hero d_hero;
    public Config_D_cardpool d_cardpool;
    public Config_D_weapon d_weapon;
    public Config_D_skill d_skill;
    public Config_CardPoolPossibility cardpools;
    public Config_MarketCardPossiblity marketcards;
    void Awake()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        //hd = uf.LoadStructFromJson<HeroData>("Data/HeroData");
        market.Init();
        LoadConfig();
        ComputeHeroFeature();
        ComputeMarketCard();
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
        cardpools = uf.LoadStructFromJson<Config_CardPoolPossibility>("Config/Config_CardPool");
        marketcards = uf.LoadStructFromJson<Config_MarketCardPossiblity>("Config/Config_MarketCard");
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
    void ComputeMarketCard()
    {
        for(int i=0;i<cards.cards.Count;i++)
        {
            if (cards.cards[i].kind == 0)
            {
                switch (cards.cards[i].rare)
                {
                    case 0:
                        market.weaponCard_0.Add(i);
                        break;
                    case 1:
                        market.weaponCard_1.Add(i);
                        break;
                    case 2:
                        market.weaponCard_2.Add(i);
                        break;
                    case 3:
                        market.weaponCard_3.Add(i);
                        break;
                    case 4:
                        market.weaponCard_4.Add(i);
                        break;
                }
            }
            else if(cards.cards[i].kind == 1){
                switch(cards.cards[i].rare)
                {
                    case 0:
                        market.itemCard_0.Add(i);
                        break;
                    case 1:
                        market.itemCard_1.Add(i);
                        break;
                    case 2:
                        market.itemCard_2.Add(i);
                        break;
                    case 3:
                        market.itemCard_3.Add(i);
                        break;
                    case 4:
                        market.itemCard_4.Add(i);
                        break;
                }
            }
            else if (cards.cards[i].kind == 1)
            {
                switch(cards.cards[i].rare)
                {
                    case 0:
                        market.scrollCard_0.Add(i);
                        break;
                    case 1:
                        market.scrollCard_1.Add(i);
                        break;
                    case 2:
                        market.scrollCard_2.Add(i);
                        break;
                    case 3:
                        market.scrollCard_3.Add(i);
                        break;
                    case 4:
                        market.scrollCard_4.Add(i);
                        break;
                }
            }
        }
    }
}
