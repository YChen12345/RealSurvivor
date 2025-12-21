using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class HeroChoose_BuyHero : MonoBehaviour
{
    public int heroID;
    public int cost;
    public TextMeshProUGUI tips;
    public TextMeshProUGUI tips_cost;
    int state;
    public GameObject hero;
    public GameObject image;
    IUF uf;
    PlayerData pd;
    Effect_ButtonText eft;
    void Start()
    {
        uf = new Functions();
        //bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        GetComponent<Button>().onClick.AddListener(BuyHero);
        image.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("HeroCard",heroID);
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        eft = GetComponent<Effect_ButtonText>();
        tips_cost.text = "金币:" +cost;
        if (pd.money >= cost)
        {
            if (state != 1)
            {
                state = 1;
                eft.mode = 1;
                tips.text = "待解锁";
            }           
        }
        else
        {
            if (state != 0)
            {
                state = 0;
                eft.mode = 0;
                tips.text = "金币不足";
            }
        }
        if (pd.heroList.Contains(heroID))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (pd.money >= cost)
        {
            if (state != 1)
            {
                state = 1;
                eft.mode = 1;
                tips.text = "待解锁";
            }
        }
        else
        {
            if (state != 0)
            {
                state = 0;
                eft.mode = 0;
                tips.text = "金币不足";
            }
        }
    }
    void BuyHero()
    {
        if (pd.money >= cost)
        {
            pd.money -= cost;
            pd.heroList.Add(heroID);
            uf.SaveStructToJson<PlayerData>(pd, "Data/PlayerData");
            hero.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
