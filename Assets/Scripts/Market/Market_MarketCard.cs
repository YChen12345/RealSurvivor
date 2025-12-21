using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_MarketCard : MonoBehaviour
{
    public int cid;
    public int cost;
    public GameObject button_buy;
    public GameObject tip_sellout;
    public Market_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        tip_sellout.SetActive(false);
        button_buy.GetComponent<Button>().onClick.AddListener(Buy);
    }

    // Update is called once per frame
    void Buy()
    {
        if (data.bd.gold >= cost)
        {
            data.bd.gold -= cost;
            data.bd.cardList_Total.Add(cid);
            data.bd.cardList_Weapon.Add(cid);
            button_buy.SetActive(false);
            tip_sellout.SetActive(true);
            this.gameObject.SetActive(false);///
        }
    }
}
