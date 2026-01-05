using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_MarketCard : MonoBehaviour
{
    public int index;
    public int cid;
    public int cost;
    public GameObject canvas;
    public GameObject button_buy;
    public GameObject tip_sellout;
    public Market_Info data;
    IUITools tools_Trigger = new UITools();
    public GameObject trigger;
    public GameObject detail;
    public TextMeshProUGUI text_cost;
    int click_state;
    float click_timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        cost = (int)(data.market.card_cost[data.cards.cards[cid].rare]*(1+0.1f*data.bd.wave));
        tip_sellout.SetActive(false);
        button_buy.GetComponent<Button>().onClick.AddListener(Buy);
        tools_Trigger.AddButtonClick(trigger);
    }
    private void Update()
    {
        SeeDetail();
        text_cost.text = "" + cost;
    }

    // Update is called once per frame
    void Buy()
    {
        if (data.bd.gold >= cost)
        {
            data.bd.gold -= cost;
            data.bd.cardList_Total.Add(cid);
            switch (data.cards.cards[cid].kind)
            {
                case 0:
                    data.bd.cardList_Weapon.Add(cid);
                    break;
                case 1:
                    data.bd.cardList_Item.Add(cid);
                    break;
                case 2:
                    data.bd.cardList_Scroll.Add(cid);
                    break;
            }
            data.bd.market_sellCard_state[index] = 1;
            button_buy.SetActive(false);
            tip_sellout.SetActive(true);
            this.gameObject.SetActive(false);///
        }
    }
    void SeeDetail()
    {
        if (click_state == 0)
        {
            if (tools_Trigger.ButtonClicked())
            {
                click_state = 1;
                click_timer = 0;
            }
        }
        else if (click_state == 1)
        {
            click_timer += Time.deltaTime;
            if (click_timer > 0.3f)
            {
                click_timer = 0;
                click_state = 0;
            }
            if (tools_Trigger.ButtonClicked())
            {
                click_state = 0;
                GameObject d = GameObject.Instantiate(detail, canvas.transform);
                d.GetComponent<Market_CardDetail>().cid = cid;
                d.SetActive(true);
            }
        }
    }
}
