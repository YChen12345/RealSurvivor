using UnityEngine;

public class Market_Info : MonoBehaviour
{
    IUF uf;
    public BattleData bd;
    public HeroData hd;
    public Market market;
    void Awake()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        hd = uf.LoadStructFromJson<HeroData>("Data/HeroData");
        market.Init();
    }

}
