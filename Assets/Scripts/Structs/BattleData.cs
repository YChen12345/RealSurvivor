using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct BattleData
{
    public int heroID;
    public int weaponID;
    public int levelID;
    public int currentLevel;
    public int round;
    public int heroLev;
    public int exp;
    public int gold;
    public int awardNum;
    public int treasureNum;
    public List<int> SkillList;
    public List<int> cardList_Total;
    public List<int> cardList_Weapon;
    public List<int> cardList_Item;
    public List<int> cardList_Scroll;
    public List<int> cardList_Used;
    public List<int> WeaponCardList;
    public List<int> ItemCardList;
    public List<int> ScrollCardList;
    public GameObject boss;
    public List<GameObject> seedList;
    public List<GameObject> emyList;
    public GameObject player;
    public int marketLevel;
    public int weaponLimit;
    public int itemLimit;
    public void Init()
    {
        heroID = 0;
        weaponID = 0;
        levelID = 0;
        currentLevel = 0;
        round = 0;
        heroLev = 1;
        exp = 0;
        gold = 60;
        awardNum = 0;
        treasureNum = 0;
        SkillList = new List<int>();
        cardList_Total = new List<int>();
        cardList_Weapon = new List<int>();
        cardList_Item = new List<int>();
        cardList_Scroll = new List<int>();
        cardList_Used = new List<int>();
        WeaponCardList = new List<int>();
        ItemCardList = new List<int>();
        ScrollCardList = new List<int>();
        boss = null;
        seedList = new List<GameObject>();
        emyList = new List<GameObject>();
        
        player = null;
    }
    public void NewBattle()
    {
        awardNum = 0;
        treasureNum = 0;
        boss = null;
        seedList = new List<GameObject>();
        emyList = new List<GameObject>();
        player = null;
    }
}

