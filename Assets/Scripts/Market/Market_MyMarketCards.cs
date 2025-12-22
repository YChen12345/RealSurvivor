using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_MyMarketCards : MonoBehaviour
{
    public List<GameObject> template;
    public GameObject marketcard;
    public GameObject button_lock;
    public GameObject button_unlock;
    public GameObject button_refresh;
    List<GameObject> display_list = new List<GameObject>();  
    public Market_Info data;
   
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button_lock.GetComponent<Button>().onClick.AddListener(Lock);
        button_unlock.GetComponent<Button>().onClick.AddListener(UnLock);
        button_refresh.GetComponent<Button>().onClick.AddListener(Refresh);
        if (data.bd.market_lockCard_state == 1)
        {
            button_lock.SetActive(false);
            button_unlock.SetActive(true);
        }
        else
        {
            button_lock.SetActive(true);
            button_unlock.SetActive(false);
        }
        SetProduct();
    }
    void SetProductList()
    {
        if(data.bd.market_lockCard_state == 0)
        {
            data.bd.market_Card.Clear();
            data.bd.market_sellCard_state.Clear();
            for (int i = 0; i < template.Count; i++)
            {
                data.bd.market_Card.Add(0);
                data.bd.market_sellCard_state.Add(0);
            }
        }
        else
        {
            for (int i = 0; i < template.Count; i++)
            {
                if (data.bd.market_sellCard_state[i] != 0)
                {
                    data.bd.market_sellCard_state[i] = 0;
                    data.bd.market_Card[i] = 0;
                }
            }
        }
    }
    void SetProduct()
    {
        SetProductList();
        for (int i = 0; i < display_list.Count; i++)
        {
            if (display_list[i] != null)
            {
                Destroy(display_list[i]);
            }
        }
        display_list.Clear();
        for(int i = 0; i < template.Count; i++)
        {
            GameObject p = GameObject.Instantiate(marketcard, marketcard.transform.parent);
            p.transform.position = template[i].transform.position;
            p.GetComponent<Market_CardDisplay>().cid = data.bd.market_Card[i];
            p.GetComponent<Market_MarketCard>().cid = data.bd.market_Card[i];
            p.GetComponent<Market_MarketCard>().index = i;
            display_list.Add(p);
            p.SetActive(true);
        }
    }
    void Lock()
    {
        data.bd.market_lockCard_state = 1;
        button_lock.SetActive(false);
        button_unlock.SetActive(true);
    }
    void UnLock()
    {
        data.bd.market_lockCard_state = 0;
        button_lock.SetActive(true);
        button_unlock.SetActive(false);
    }
    void Refresh()
    {
        SetProductList();
        for (int i = 0; i < display_list.Count; i++)
        {
            if (display_list[i] != null)
            {
                Destroy(display_list[i]);
            }
        }
        display_list.Clear();
        for (int i = 0; i < template.Count; i++)
        {
            GameObject p = GameObject.Instantiate(marketcard, marketcard.transform.parent);
            p.transform.position = template[i].transform.position;
            p.GetComponent<Market_CardDisplay>().cid = data.bd.market_Card[i];
            p.GetComponent<Market_MarketCard>().cid = data.bd.market_Card[i];
            p.GetComponent<Market_MarketCard>().index = i;
            display_list.Add(p);
            p.SetActive(true);
        }
    }
}
