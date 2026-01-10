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
    public int refresh_cost;
    public TextMeshProUGUI text_refreshcost;
    int slots_state;
   
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button_lock.GetComponent<Button>().onClick.AddListener(Lock);
        button_unlock.GetComponent<Button>().onClick.AddListener(UnLock);
        button_refresh.GetComponent<Button>().onClick.AddListener(Refresh);
        refresh_cost = data.market.refreshMarketCard_cost;
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
    private void Update()
    {
        text_refreshcost.text = "" + refresh_cost;
        slots_state = 0;
        for (int i = 0; i < display_list.Count;i++)
        {
            if (display_list[i].activeSelf == false)
            {
                slots_state = 1;
                break;
            }
        }
        if (data.bd.market_lockCard_state == 1 && slots_state==0)
        {
            button_refresh.SetActive(false);
        }
        else
        {
            button_refresh.SetActive(true);
        }
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
        if (data.bd.gold >= refresh_cost)
        {
            data.bd.gold -= refresh_cost;
            refresh_cost +=(int)(0.2f* data.market.refreshMarketCard_cost);
            /////////////////
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
    int RandomCard()
    {
        int lid = 0;
        if (data.bd.wave < 4)
        {
            lid = 0;
        }
        else if(data.bd.wave <8)
        {
            lid = 1;
        }
        else if (data.bd.wave < 12)
        {
            lid = 2;
        }
        else if (data.bd.wave < 16)
        {
            lid = 3;
        }
        else
        {
            lid = 4;
        }
        int cid = Random.Range(0, data.cards.cards.Count);///////////////////////
        float r = Random.value;
        MarketPossiblity mp = data.marketcards.possiblity[lid];
        if (r < mp.possiblity_kind[0])
        {
            if (true)
            {
                if (data.market.weaponCard_0.Count > 0)
                {
                    cid = data.market.weaponCard_0[Random.Range(0, data.market.weaponCard_0.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[1]))
            {
                if (data.market.weaponCard_1.Count > 0)
                {
                    cid = data.market.weaponCard_1[Random.Range(0, data.market.weaponCard_1.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[2]))
            {
                if (data.market.weaponCard_2.Count > 0)
                {
                    cid = data.market.weaponCard_2[Random.Range(0, data.market.weaponCard_2.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[3]))
            {
                if (data.market.weaponCard_3.Count > 0)
                {
                    cid = data.market.weaponCard_3[Random.Range(0, data.market.weaponCard_3.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[4]))
            {
                if (data.market.weaponCard_4.Count > 0)
                {
                    cid = data.market.weaponCard_4[Random.Range(0, data.market.weaponCard_4.Count)];
                }
            }
        }
        else if (r < mp.possiblity_kind[1])
        {
            if (true)
            {
                if (data.market.itemCard_0.Count > 0)
                {
                    cid = data.market.itemCard_0[Random.Range(0, data.market.itemCard_0.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[1]))
            {
                if (data.market.itemCard_1.Count > 0)
                {
                    cid = data.market.itemCard_1[Random.Range(0, data.market.itemCard_1.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[2]))
            {
                if (data.market.itemCard_2.Count > 0)
                {
                    cid = data.market.itemCard_2[Random.Range(0, data.market.itemCard_2.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[3]))
            {
                if (data.market.itemCard_3.Count > 0)
                {
                    cid = data.market.itemCard_3[Random.Range(0, data.market.itemCard_3.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[4]))
            {
                if (data.market.itemCard_4.Count > 0)
                {
                    cid = data.market.itemCard_4[Random.Range(0, data.market.itemCard_4.Count)];
                }
            }
        }
        else
        {
            if (true)
            {
                if (data.market.scrollCard_0.Count > 0)
                {
                    cid = data.market.scrollCard_0[Random.Range(0, data.market.scrollCard_0.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[1]))
            {
                if (data.market.scrollCard_1.Count > 0)
                {
                    cid = data.market.scrollCard_1[Random.Range(0, data.market.scrollCard_1.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[2]))
            {
                if (data.market.scrollCard_2.Count > 0)
                {
                    cid = data.market.scrollCard_2[Random.Range(0, data.market.scrollCard_2.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[3]))
            {
                if (data.market.scrollCard_3.Count > 0)
                {
                    cid = data.market.scrollCard_3[Random.Range(0, data.market.scrollCard_3.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[4]))
            {
                if (data.market.scrollCard_4.Count > 0)
                {
                    cid = data.market.scrollCard_4[Random.Range(0, data.market.scrollCard_4.Count)];
                }
            }
        }
        return cid;
    }
}
