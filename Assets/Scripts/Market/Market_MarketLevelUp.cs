using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_MarketLevelUp : MonoBehaviour
{
    public int cost;
    public GameObject button_buy;
    public GameObject tip_sellout;
    public Market_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button_buy.GetComponent<Button>().onClick.AddListener(Buy);
        tip_sellout.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (data.bd.marketLevel >= 4)
        {
            button_buy.SetActive(false);
            tip_sellout.SetActive(true);
        }
    }
    void Buy()
    {
        if (data.bd.marketLevel < 4)
        {
            if (data.bd.gold >= cost)
            {
                data.bd.gold -= cost;
                data.bd.marketLevel++;
            }
        }
    }
}
