using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CardScreen_RefreshHandCardPage : MonoBehaviour
{
    int cost;
    public GameObject button_refresh;
    public GameObject button_cancel;
    public CardScreen_Info data;
    IUF uf = new UIFunctions();
    public GameObject handCardManager;
    public TextMeshProUGUI content_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cost = 3;
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        content_text.text = "是否花费" + cost + "点能量刷新所有手牌？\n（当前所有手牌将会被弃置）";
        button_cancel.GetComponent<Button>().onClick.AddListener(Cancel);
        button_refresh.GetComponent<Button>().onClick.AddListener(Refresh);
        if (data.bd.mana < cost)
        {
            button_refresh.SetActive(false);
        }
    }
    void Cancel()
    {
        Destroy(this.gameObject);
    }
    void Refresh()
    {
        if (data.bd.mana >= cost)
        {
            data.bd.mana -= cost;
            handCardManager.GetComponent<CardScreen_HandCardManager>().ReSetHandCard();
            Destroy(this.gameObject);
        }
    }
}
