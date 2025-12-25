using System.Collections.Generic;
using UnityEngine;

public class CardScreen_Info : MonoBehaviour
{
    IUF uf;
    public BattleData bd;
    public HeroData hd;
    public CardScreen cardScreen;
    void Awake()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        hd = uf.LoadStructFromJson<HeroData>("Data/HeroData");
        cardScreen.Init();
        cardScreen.remainCard = new List<int>(bd.cardList_Total);
        cardScreen.remainCard_weapon = new List<int>(bd.cardList_Weapon);
        cardScreen.remainCard_item = new List<int>(bd.cardList_Item);
        cardScreen.remainCard_scroll = new List<int>(bd.cardList_Scroll);
    }
}
