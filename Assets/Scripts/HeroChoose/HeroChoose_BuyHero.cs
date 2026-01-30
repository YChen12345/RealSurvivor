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
    Effect_ButtonText eft;
    public HeroChoose_Info data;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("HeroChoose").GetComponent<HeroChoose_Info>();
        GetComponent<Button>().onClick.AddListener(BuyHero);
        image.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("HeroCard",heroID);
        eft = GetComponent<Effect_ButtonText>();
        cost = heroID * 200;
        tips_cost.text = "钻石:" +cost;
        if (data.pd.money >= cost)
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
                tips.text = "钻石不足";
            }
        }
        if (data.pd.heroList.Contains(heroID))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (data.pd.money >= cost)
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
                tips.text = "钻石不足";
            }
        }
    }
    void BuyHero()
    {
        if (data.pd.money >= cost)
        {
            data.pd.money -= cost;
            data.pd.heroList.Add(heroID);
            uf.SaveStructToJson<PlayerData>(data.pd, "Data/PlayerData");
            hero.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
