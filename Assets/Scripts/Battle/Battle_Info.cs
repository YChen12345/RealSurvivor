using System.Collections.Generic;
using System.Linq;
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
    public Config_D_enemy d_enemy;
    public Config_D_card d_card;
    public Config_D_hero d_hero;
    public Config_D_cardpool d_cardpool;
    public Config_D_weapon d_weapon;
    public Config_D_skill d_skill;
    public Config_MarketCardPossiblity marketcards;


    public BattleData bd;
    public HeroData hd;
    public CardClassification cc;
    public float totaltime;
    public float generation_t;
    public float clock;
    public float generateGapClock;
    public float map_width;
    public float map_height;
    public int maxEmyInScreen;
    public int state;
    public int page_state;
    public int settlement;
    public int dead;
    public int settlement_state;
    public int genIndex;
    public List<int> emyList = new List<int>();
    public int unpicked;
    void Awake()
    {
        uf = new Functions();
        unpicked = 0;
        totaltime = 0;
        generation_t = 0;
        genIndex = 0;
        //Save();
        LoadConfig();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");     
        bd.NewBattle();
        cc.Init();
        ComputeHeroFeature();
        ComputeCardClassification();
        bd.player = GameObject.Find("Player");
        map_width = 10.35f * 2;
        map_height = 7.54f * 2;
        ////
        clock = levels.levels[bd.wave].clock;
        maxEmyInScreen = levels.levels[bd.wave].maxEmyInScreen;
        //generateGapClock = levels.levels[bd.wave].generateGapClock;
        for(int i = 0; i < levels.levels[bd.wave].enemyid.Count; i++)
        {
            if(i< levels.levels[bd.wave].enemynum.Count)
            {
                for (int j = 0; j < levels.levels[bd.wave].enemynum[i]; j++)
                {
                    emyList.Add(levels.levels[bd.wave].enemyid[i]);
                }
            }       
        }
        emyList = new List<int>(emyList.OrderBy(x => Random.value).ToList());
        generateGapClock = clock / emyList.Count;
        bd.mana = hd.mana;
    }
    public void ComputeHeroFeature()
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
        marketcards = uf.LoadStructFromJson<Config_MarketCardPossiblity>("Config/Config_MarketCard");
        d_enemy = uf.LoadStructFromJson<Config_D_enemy>("Config/D/Config_D_enemy");
        d_card = uf.LoadStructFromJson<Config_D_card>("Config/D/Config_D_card");
        d_hero = uf.LoadStructFromJson<Config_D_hero>("Config/D/Config_D_hero");
        d_cardpool = uf.LoadStructFromJson<Config_D_cardpool>("Config/D/Config_D_cardpool");
        d_weapon = uf.LoadStructFromJson<Config_D_weapon>("Config/D/Config_D_weapon");
        d_skill = uf.LoadStructFromJson<Config_D_skill>("Config/D/Config_D_skill");
    }
    void ComputeCardClassification()
    {
        for (int i = 0; i < cards.cards.Count; i++)
        {
            if (cards.cards[i].kind == 0)
            {
                switch (cards.cards[i].rare)
                {
                    case 0:
                        cc.weaponCard_0.Add(i);
                        break;
                    case 1:
                        cc.weaponCard_1.Add(i);
                        break;
                    case 2:
                        cc.weaponCard_2.Add(i);
                        break;
                    case 3:
                        cc.weaponCard_3.Add(i);
                        break;
                    case 4:
                        cc.weaponCard_4.Add(i);
                        break;
                }
            }
            else if (cards.cards[i].kind == 1)
            {
                switch (cards.cards[i].rare)
                {
                    case 0:
                        cc.itemCard_0.Add(i);
                        break;
                    case 1:
                        cc.itemCard_1.Add(i);
                        break;
                    case 2:
                        cc.itemCard_2.Add(i);
                        break;
                    case 3:
                        cc.itemCard_3.Add(i);
                        break;
                    case 4:
                        cc.itemCard_4.Add(i);
                        break;
                }
            }
            else if (cards.cards[i].kind == 1)
            {
                switch (cards.cards[i].rare)
                {
                    case 0:
                        cc.scrollCard_0.Add(i);
                        break;
                    case 1:
                        cc.scrollCard_1.Add(i);
                        break;
                    case 2:
                        cc.scrollCard_2.Add(i);
                        break;
                    case 3:
                        cc.scrollCard_3.Add(i);
                        break;
                    case 4:
                        cc.scrollCard_4.Add(i);
                        break;
                }
            }
        }
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
        d_card.Init();
        d_cardpool.Init();
        d_enemy.Init();
        d_hero.Init();
        d_skill.Init();
        d_weapon.Init();
        Enemy e = new Enemy();
        HeroData h = new HeroData();
        Level l = new Level();
        l.Init();
        Drop d = new Drop();
        Skill s = new Skill();
        CardDescription dc = new CardDescription();
        CardPoolDescription dp = new CardPoolDescription();
        EnemyDescription de = new EnemyDescription();
        HeroDescription dh = new HeroDescription();
        SkillDescription ds = new SkillDescription();
        WeaponDescription dw = new WeaponDescription();
        heros.heros.Add(h);
        heros.heros.Add(h);
        levels.levels.Add(l);
        levels.levels.Add(l);
        drops.drops.Add(d);
        drops.drops.Add(d);
        skills.skills.Add(s);
        skills.skills.Add(s);
        d_enemy.enemyDesList.Add(de);
        d_enemy.enemyDesList.Add(de);
        d_card.cardDesList.Add(dc);
        d_card.cardDesList.Add(dc);
        d_hero.heroDesList.Add(dh);
        d_hero.heroDesList.Add(dh);
        d_cardpool.cardPoolDesList.Add(dp);
        d_cardpool.cardPoolDesList.Add(dp);
        d_weapon.weaponDesList.Add(dw);
        d_weapon.weaponDesList.Add(dw);
        d_skill.skillDesList.Add(ds);
        d_skill.skillDesList.Add(ds);
        //uf.SaveStructToJson<Config_Enemy>(enemies, "Config/Config_Enemy");
        //uf.SaveStructToJson<Config_Weapon>(weapons, "Config/Config_Weapon");
        //uf.SaveStructToJson<Config_Card>(cards, "Config/Config_Card");
        //uf.SaveStructToJson<Config_Hero>(heros, "Config/Config_Hero");
        //uf.SaveStructToJson<Config_Level>(levels, "Config/Config_Level");
        //uf.SaveStructToJson<Config_Drop>(drops, "Config/Config_Drop");
        //uf.SaveStructToJson<Config_Skill>(skills, "Config/Config_Skill");
        uf.SaveStructToJson<Config_D_enemy>(d_enemy, "Config/D/Config_D_enemy");
        uf.SaveStructToJson<Config_D_card>(d_card, "Config/D/Config_D_card");
        uf.SaveStructToJson<Config_D_hero>(d_hero, "Config/D/Config_D_hero");
        uf.SaveStructToJson<Config_D_cardpool>(d_cardpool, "Config/D/Config_D_cardpool");
        uf.SaveStructToJson<Config_D_weapon>(d_weapon, "Config/D/Config_D_weapon");
        uf.SaveStructToJson<Config_D_skill>(d_skill, "Config/D/Config_D_skill");
    }
}
