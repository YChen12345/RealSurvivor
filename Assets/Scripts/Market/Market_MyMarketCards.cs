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
    IUF uf = new UIFunctions();
   
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
                int cid = RandomCard();        
                data.bd.market_Card.Add(cid);//////////////////////////
                data.bd.market_sellCard_state.Add(0);
            }
        }
        else
        {
            for (int i = 0; i < template.Count; i++)
            {
                int cid = RandomCard();
                if (data.bd.market_sellCard_state[i] != 0)
                {
                    data.bd.market_Card[i] = cid;//////////////////////////
                    data.bd.market_sellCard_state[i] = 0;                 
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
    int RandomCard()
    {
        int cid = Random.Range(0, data.cards.cards.Count);///////////////////////
        float r = Random.value;
        if (r<0.6f)
        {
            if (data.bd.wave < 5)
            {
                if (data.market.weaponCard_0.Count > 0)
                {
                    cid = data.market.weaponCard_0[Random.Range(0, data.market.weaponCard_0.Count)];
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.weaponCard_1.Count > 0)
                    {
                        cid = data.market.weaponCard_1[Random.Range(0, data.market.weaponCard_1.Count)];
                    }
                }              
            }
            else if(data.bd.wave < 10)
            {
                if (data.market.weaponCard_0.Count > 0)
                {
                    cid = data.market.weaponCard_0[Random.Range(0, data.market.weaponCard_0.Count)];
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.weaponCard_1.Count > 0)
                    {
                        cid = data.market.weaponCard_1[Random.Range(0, data.market.weaponCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.1f))
                {
                    if (data.market.weaponCard_2.Count > 0)
                    {
                        cid = data.market.weaponCard_2[Random.Range(0, data.market.weaponCard_2.Count)];
                    }
                }
            }
            else if (data.bd.wave < 15)
            {
                if (data.market.weaponCard_0.Count > 0)
                {
                    cid = data.market.weaponCard_0[Random.Range(0, data.market.weaponCard_0.Count)];
                }
                if (uf.RandomRes(0.6f))
                {
                    if (data.market.weaponCard_1.Count > 0)
                    {
                        cid = data.market.weaponCard_1[Random.Range(0, data.market.weaponCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.2f))
                {
                    if (data.market.weaponCard_2.Count > 0)
                    {
                        cid = data.market.weaponCard_2[Random.Range(0, data.market.weaponCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.05f))
                {
                    if (data.market.weaponCard_3.Count > 0)
                    {
                        cid = data.market.weaponCard_3[Random.Range(0, data.market.weaponCard_3.Count)];
                    }
                }
            }
            else
            {
                if (data.market.weaponCard_0.Count > 0)
                {
                    cid = data.market.weaponCard_0[Random.Range(0, data.market.weaponCard_0.Count)];
                }
                if (uf.RandomRes(0.6f))
                {
                    if (data.market.weaponCard_1.Count > 0)
                    {
                        cid = data.market.weaponCard_1[Random.Range(0, data.market.weaponCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.35f))
                {
                    if (data.market.weaponCard_2.Count > 0)
                    {
                        cid = data.market.weaponCard_2[Random.Range(0, data.market.weaponCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.15f))
                {
                    if (data.market.weaponCard_3.Count > 0)
                    {
                        cid = data.market.weaponCard_3[Random.Range(0, data.market.weaponCard_3.Count)];
                    }
                }
                if (uf.RandomRes(0.05f))
                {
                    if (data.market.weaponCard_4.Count > 0)
                    {
                        cid = data.market.weaponCard_4[Random.Range(0, data.market.weaponCard_4.Count)];
                    }
                }
            }
        }
        else if(r<0.9f)
        {
            if (data.bd.wave < 5)
            {
                if (data.market.itemCard_0.Count > 0)
                {
                    cid = data.market.itemCard_0[Random.Range(0, data.market.itemCard_0.Count)];
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.itemCard_1.Count > 0)
                    {
                        cid = data.market.itemCard_1[Random.Range(0, data.market.itemCard_1.Count)];
                    }
                }
            }
            else if (data.bd.wave < 10)
            {
                if (data.market.itemCard_0.Count > 0)
                {
                    cid = data.market.itemCard_0[Random.Range(0, data.market.itemCard_0.Count)];
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.itemCard_1.Count > 0)
                    {
                        cid = data.market.itemCard_1[Random.Range(0, data.market.itemCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.1f))
                {
                    if (data.market.itemCard_2.Count > 0)
                    {
                        cid = data.market.itemCard_2[Random.Range(0, data.market.itemCard_2.Count)];
                    }
                }
            }
            else if (data.bd.wave < 15)
            {
                if (data.market.itemCard_0.Count > 0)
                {
                    cid = data.market.itemCard_0[Random.Range(0, data.market.itemCard_0.Count)];
                }
                if (uf.RandomRes(0.6f))
                {
                    if (data.market.itemCard_1.Count > 0)
                    {
                        cid = data.market.itemCard_1[Random.Range(0, data.market.itemCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.2f))
                {
                    if (data.market.itemCard_2.Count > 0)
                    {
                        cid = data.market.itemCard_2[Random.Range(0, data.market.itemCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.05f))
                {
                    if (data.market.itemCard_3.Count > 0)
                    {
                        cid = data.market.itemCard_3[Random.Range(0, data.market.itemCard_3.Count)];
                    }
                }
            }
            else
            {
                if (data.market.itemCard_0.Count > 0)
                {
                    cid = data.market.itemCard_0[Random.Range(0, data.market.itemCard_0.Count)];
                }
                if (uf.RandomRes(0.6f))
                {
                    if (data.market.itemCard_1.Count > 0)
                    {
                        cid = data.market.itemCard_1[Random.Range(0, data.market.itemCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.35f))
                {
                    if (data.market.itemCard_2.Count > 0)
                    {
                        cid = data.market.itemCard_2[Random.Range(0, data.market.itemCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.15f))
                {
                    if (data.market.itemCard_3.Count > 0)
                    {
                        cid = data.market.itemCard_3[Random.Range(0, data.market.itemCard_3.Count)];
                    }
                }
                if (uf.RandomRes(0.05f))
                {
                    if (data.market.itemCard_4.Count > 0)
                    {
                        cid = data.market.itemCard_4[Random.Range(0, data.market.itemCard_4.Count)];
                    }
                }
            }
        }
        else
        {
            if (data.bd.wave < 5)
            {
                if (data.market.scrollCard_0.Count > 0)
                {
                    cid = data.market.scrollCard_0[Random.Range(0, data.market.scrollCard_0.Count)];
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.scrollCard_1.Count > 0)
                    {
                        cid = data.market.scrollCard_1[Random.Range(0, data.market.scrollCard_1.Count)];
                    }
                }
            }
            else if (data.bd.wave < 10)
            {
                if (data.market.scrollCard_0.Count > 0)
                {
                    cid = data.market.scrollCard_0[Random.Range(0, data.market.scrollCard_0.Count)];
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.scrollCard_1.Count > 0)
                    {
                        cid = data.market.scrollCard_1[Random.Range(0, data.market.scrollCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.1f))
                {
                    if (data.market.scrollCard_2.Count > 0)
                    {
                        cid = data.market.scrollCard_2[Random.Range(0, data.market.scrollCard_2.Count)];
                    }
                }
            }
            else if (data.bd.wave < 15)
            {
                if (data.market.scrollCard_0.Count > 0)
                {
                    cid = data.market.scrollCard_0[Random.Range(0, data.market.scrollCard_0.Count)];
                }
                if (uf.RandomRes(0.6f))
                {
                    if (data.market.scrollCard_1.Count > 0)
                    {
                        cid = data.market.scrollCard_1[Random.Range(0, data.market.scrollCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.2f))
                {
                    if (data.market.scrollCard_2.Count > 0)
                    {
                        cid = data.market.scrollCard_2[Random.Range(0, data.market.scrollCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.05f))
                {
                    if (data.market.scrollCard_3.Count > 0)
                    {
                        cid = data.market.scrollCard_3[Random.Range(0, data.market.scrollCard_3.Count)];
                    }
                }
            }
            else
            {
                if (data.market.scrollCard_0.Count > 0)
                {
                    cid = data.market.scrollCard_0[Random.Range(0, data.market.scrollCard_0.Count)];
                }
                if (uf.RandomRes(0.6f))
                {
                    if (data.market.scrollCard_1.Count > 0)
                    {
                        cid = data.market.scrollCard_1[Random.Range(0, data.market.scrollCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.35f))
                {
                    if (data.market.scrollCard_2.Count > 0)
                    {
                        cid = data.market.scrollCard_2[Random.Range(0, data.market.scrollCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.15f))
                {
                    if (data.market.scrollCard_3.Count > 0)
                    {
                        cid = data.market.scrollCard_3[Random.Range(0, data.market.scrollCard_3.Count)];
                    }
                }
                if (uf.RandomRes(0.05f))
                {
                    if (data.market.scrollCard_4.Count > 0)
                    {
                        cid = data.market.scrollCard_4[Random.Range(0, data.market.scrollCard_4.Count)];
                    }
                }
            }
        }
        return cid;
    }
}
