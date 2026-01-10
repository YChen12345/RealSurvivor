using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Market_RemovePage : MonoBehaviour
{
    public GameObject button_yes;
    public GameObject button_no;
    public int rid;
    public Market_Info data;
    public int cost;
    public TextMeshProUGUI content_text;
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        cost = data.market.discard_cost;
        content_text.text = "是否花费" + cost + "金币销毁此卡牌？";
        button_yes.GetComponent<Button>().onClick.AddListener(Yes);
        button_no.GetComponent<Button>().onClick.AddListener(No);
    }
    private void Update()
    {
        if (data.bd.gold < cost)
        {
            button_yes.SetActive(false);
        }
    }
    void Yes()
    {
        if (data.bd.gold >= cost)
        {
            data.bd.gold -= cost;
            data.bd.cardList_Total.Remove(rid);
            data.bd.cardList_Weapon.Remove(rid);
            data.bd.cardList_Item.Remove(rid);
            data.bd.cardList_Scroll.Remove(rid);
            Destroy(this.gameObject);
        }
    }
    void No()
    {
        Destroy(this.gameObject);
    }
}
