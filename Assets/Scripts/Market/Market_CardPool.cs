using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_CardPool : MonoBehaviour
{
    public int pid;
    public int cost;
    public GameObject canvas;
    public GameObject icon;
    public GameObject detail;
    public TextMeshProUGUI text_name;
    public TextMeshProUGUI text_cost;
    public GameObject button_buy;
    //public GameObject tip_sellout;
    public GameObject drawCardPage;
    public Market_Info data;
    IUF uf = new UIFunctions();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button_buy.GetComponent<Button>().onClick.AddListener(Buy);
        icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("CardPool", pid);
        text_name.text = data.d_cardpool.cardPoolDesList[pid].cardpool_name;
        cost = data.market.draw_cost[pid];
        detail.GetComponent<Market_CardPoolDetail>().pid = pid;
    }
    private void Update()
    {
        text_cost.text = "" + cost;
    }
    void Buy()
    {
        if (data.bd.gold >= cost)
        {
            data.bd.gold-=cost;
            cost += (int)(data.market.draw_cost[pid] * 0.1f);
            GameObject p = GameObject.Instantiate(drawCardPage, canvas.transform);
            p.GetComponent<Market_DrawCard>().pid = pid;
            p.GetComponent<Market_DrawCard>().cid = RandomCard();
            p.SetActive(true);
        }
    }
    int RandomCard()
    {
        int cid = Random.Range(0, data.cards.cards.Count);///////////////////////
        float r = Random.value;
        if (r < 0.3f)
        {
            if (pid==0)
            {
                if (data.market.weaponCard_0.Count > 0)
                {
                    cid = data.market.weaponCard_0[Random.Range(0, data.market.weaponCard_0.Count)];
                }
            }
            else if (pid == 1)
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
            else if (pid == 2)
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
                if (uf.RandomRes(0.3f))
                {
                    if (data.market.weaponCard_2.Count > 0)
                    {
                        cid = data.market.weaponCard_2[Random.Range(0, data.market.weaponCard_2.Count)];
                    }
                }
            }
            else if(pid == 3)
            {
                if (data.market.weaponCard_0.Count > 0)
                {
                    cid = data.market.weaponCard_0[Random.Range(0, data.market.weaponCard_0.Count)];
                }
                if (uf.RandomRes(0.7f))
                {
                    if (data.market.weaponCard_1.Count > 0)
                    {
                        cid = data.market.weaponCard_1[Random.Range(0, data.market.weaponCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.weaponCard_2.Count > 0)
                    {
                        cid = data.market.weaponCard_2[Random.Range(0, data.market.weaponCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.1f))
                {
                    if (data.market.weaponCard_3.Count > 0)
                    {
                        cid = data.market.weaponCard_3[Random.Range(0, data.market.weaponCard_3.Count)];
                    }
                }
            }
            else if (pid == 4)
            {
                if (data.market.weaponCard_0.Count > 0)
                {
                    cid = data.market.weaponCard_0[Random.Range(0, data.market.weaponCard_0.Count)];
                }
                if (uf.RandomRes(0.8f))
                {
                    if (data.market.weaponCard_1.Count > 0)
                    {
                        cid = data.market.weaponCard_1[Random.Range(0, data.market.weaponCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.5f))
                {
                    if (data.market.weaponCard_2.Count > 0)
                    {
                        cid = data.market.weaponCard_2[Random.Range(0, data.market.weaponCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.2f))
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
        else if (r < 0.6f)
        {
            if (pid==0)
            {
                if (data.market.itemCard_0.Count > 0)
                {
                    cid = data.market.itemCard_0[Random.Range(0, data.market.itemCard_0.Count)];
                }
            }
            else if (pid==1)
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
            else if (pid==2)
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
            }
            else if(pid==3)
            {
                if (data.market.itemCard_0.Count > 0)
                {
                    cid = data.market.itemCard_0[Random.Range(0, data.market.itemCard_0.Count)];
                }
                if (uf.RandomRes(0.7f))
                {
                    if (data.market.itemCard_1.Count > 0)
                    {
                        cid = data.market.itemCard_1[Random.Range(0, data.market.itemCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.itemCard_2.Count > 0)
                    {
                        cid = data.market.itemCard_2[Random.Range(0, data.market.itemCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.1f))
                {
                    if (data.market.itemCard_3.Count > 0)
                    {
                        cid = data.market.itemCard_3[Random.Range(0, data.market.itemCard_3.Count)];
                    }
                }
            }
            else if (pid == 4)
            {
                if (data.market.itemCard_0.Count > 0)
                {
                    cid = data.market.itemCard_0[Random.Range(0, data.market.itemCard_0.Count)];
                }
                if (uf.RandomRes(0.8f))
                {
                    if (data.market.itemCard_1.Count > 0)
                    {
                        cid = data.market.itemCard_1[Random.Range(0, data.market.itemCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.5f))
                {
                    if (data.market.itemCard_2.Count > 0)
                    {
                        cid = data.market.itemCard_2[Random.Range(0, data.market.itemCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.2f))
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
            if (pid==0)
            {
                if (data.market.scrollCard_0.Count > 0)
                {
                    cid = data.market.scrollCard_0[Random.Range(0, data.market.scrollCard_0.Count)];
                }
            }
            else if (pid==1)
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
            else if (pid==2)
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
            }
            else if(pid==3)
            {
                if (data.market.scrollCard_0.Count > 0)
                {
                    cid = data.market.scrollCard_0[Random.Range(0, data.market.scrollCard_0.Count)];
                }
                if (uf.RandomRes(0.7f))
                {
                    if (data.market.scrollCard_1.Count > 0)
                    {
                        cid = data.market.scrollCard_1[Random.Range(0, data.market.scrollCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.4f))
                {
                    if (data.market.scrollCard_2.Count > 0)
                    {
                        cid = data.market.scrollCard_2[Random.Range(0, data.market.scrollCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.1f))
                {
                    if (data.market.scrollCard_3.Count > 0)
                    {
                        cid = data.market.scrollCard_3[Random.Range(0, data.market.scrollCard_3.Count)];
                    }
                }
            }
            else if (pid == 4)
            {
                if (data.market.scrollCard_0.Count > 0)
                {
                    cid = data.market.scrollCard_0[Random.Range(0, data.market.scrollCard_0.Count)];
                }
                if (uf.RandomRes(0.8f))
                {
                    if (data.market.scrollCard_1.Count > 0)
                    {
                        cid = data.market.scrollCard_1[Random.Range(0, data.market.scrollCard_1.Count)];
                    }
                }
                if (uf.RandomRes(0.5f))
                {
                    if (data.market.scrollCard_2.Count > 0)
                    {
                        cid = data.market.scrollCard_2[Random.Range(0, data.market.scrollCard_2.Count)];
                    }
                }
                if (uf.RandomRes(0.2f))
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
