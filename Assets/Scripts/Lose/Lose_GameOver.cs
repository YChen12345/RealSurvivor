using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Lose_GameOver : MonoBehaviour
{
    IUF uf;
    BattleData bd;
    PlayerData pd;
    public TextMeshProUGUI reward_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        PlayerPrefs.SetInt("State", 0);
        Reward();
        uf.SaveStructToJson<PlayerData>(pd,"Data/PlayerData");
    }

    void Reward()
    {
        pd.money += bd.wave * 10;
        reward_text.text = "获得钻石：" + bd.wave * 10;
    }
}
