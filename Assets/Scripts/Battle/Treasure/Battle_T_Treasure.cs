using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battle_T_Treasure : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject page;
    public GameObject anim;
    public GameObject card;
    public GameObject cover;
    public TextMeshProUGUI text_remain;
    public GameObject button_open;
    public GameObject button_skip;
    public GameObject button_gain;
    public GameObject button_discard;
    public Battle_Info data;
    public int cid;
    public int state;
    public float range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        SetTreasure();
        text_remain.text = "剩余" + data.bd.awardNum + "个宝箱待开启";
        button_open.GetComponent<Button>().onClick.AddListener(OpenTreasure);
        button_skip.GetComponent<Button>().onClick.AddListener(Skip);
        button_gain.GetComponent<Button>().onClick.AddListener(GainCard);
        button_discard.GetComponent<Button>().onClick.AddListener(Discard);
        button_open.SetActive(true);
        button_gain.SetActive(false);
        button_discard.SetActive(false);
        button_skip.SetActive(false);
        cover.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Cover/Treasure", 0);
        cover.SetActive(true);
    }
    void Update()
    {
        if (state == 1)
        {
            range += Time.deltaTime * 0.3f;
        }
        if (range < 0.2f)
        {
            uf.EraseTexture(cover, range);
        }
        else if (range < 0.6f)
        {
            uf.EraseTexture(cover, range);
            button_gain.SetActive(true);
            button_discard.SetActive(true);
            button_skip.SetActive(false);
        }
        else
        {
            button_gain.SetActive(true);
            button_discard.SetActive(true);
            button_skip.SetActive(false);
            anim.SetActive(false);
        }
    }
    // Update is called once per frame
    void SetTreasure()
    {
        int lid = 0;
        if (data.bd.wave < 4)
        {
            lid = 0;
        }
        else if (data.bd.wave < 8)
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
        cid = Random.Range(0, data.cards.cards.Count);
        float r = Random.value;
        MarketPossiblity mp = data.marketcards.possiblity[lid];
        if (r < mp.possiblity_kind[0])
        {
            if (true)
            {
                if (data.cc.weaponCard_0.Count > 0)
                {
                    cid = data.cc.weaponCard_0[Random.Range(0, data.cc.weaponCard_0.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[1]))
            {
                if (data.cc.weaponCard_1.Count > 0)
                {
                    cid = data.cc.weaponCard_1[Random.Range(0, data.cc.weaponCard_1.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[2]))
            {
                if (data.cc.weaponCard_2.Count > 0)
                {
                    cid = data.cc.weaponCard_2[Random.Range(0, data.cc.weaponCard_2.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[3]))
            {
                if (data.cc.weaponCard_3.Count > 0)
                {
                    cid = data.cc.weaponCard_3[Random.Range(0, data.cc.weaponCard_3.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[4]))
            {
                if (data.cc.weaponCard_4.Count > 0)
                {
                    cid = data.cc.weaponCard_4[Random.Range(0, data.cc.weaponCard_4.Count)];
                }
            }
        }
        else if (r < mp.possiblity_kind[1])
        {
            if (true)
            {
                if (data.cc.itemCard_0.Count > 0)
                {
                    cid = data.cc.itemCard_0[Random.Range(0, data.cc.itemCard_0.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[1]))
            {
                if (data.cc.itemCard_1.Count > 0)
                {
                    cid = data.cc.itemCard_1[Random.Range(0, data.cc.itemCard_1.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[2]))
            {
                if (data.cc.itemCard_2.Count > 0)
                {
                    cid = data.cc.itemCard_2[Random.Range(0, data.cc.itemCard_2.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[3]))
            {
                if (data.cc.itemCard_3.Count > 0)
                {
                    cid = data.cc.itemCard_3[Random.Range(0, data.cc.itemCard_3.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[4]))
            {
                if (data.cc.itemCard_4.Count > 0)
                {
                    cid = data.cc.itemCard_4[Random.Range(0, data.cc.itemCard_4.Count)];
                }
            }
        }
        else
        {
            if (true)
            {
                if (data.cc.scrollCard_0.Count > 0)
                {
                    cid = data.cc.scrollCard_0[Random.Range(0, data.cc.scrollCard_0.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[1]))
            {
                if (data.cc.scrollCard_1.Count > 0)
                {
                    cid = data.cc.scrollCard_1[Random.Range(0, data.cc.scrollCard_1.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[2]))
            {
                if (data.cc.scrollCard_2.Count > 0)
                {
                    cid = data.cc.scrollCard_2[Random.Range(0, data.cc.scrollCard_2.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[3]))
            {
                if (data.cc.scrollCard_3.Count > 0)
                {
                    cid = data.cc.scrollCard_3[Random.Range(0, data.cc.scrollCard_3.Count)];
                }
            }
            if (uf.RandomRes(mp.possiblity_rare[4]))
            {
                if (data.cc.scrollCard_4.Count > 0)
                {
                    cid = data.cc.scrollCard_4[Random.Range(0, data.cc.scrollCard_4.Count)];
                }
            }
        }
        card.GetComponent<Battle_T_CardDisplay>().cid = cid;
        card.SetActive(true);
    }
    void GainCard()
    {
        data.page_state = 0;
        data.bd.cardList_Total.Add(cid);
        data.bd.cardList_Weapon.Add(cid);
        data.bd.cardList_Item.Add(cid);
        data.bd.cardList_Scroll.Add(cid);
        if (data.bd.treasureNum <= 0)
        {
            data.settlement = 2;
        }
        Destroy(page);
    }
    void Discard()
    {
        data.page_state = 0;
        if (data.bd.treasureNum <= 0)
        {
            data.settlement = 2;
        }
        Destroy(page);
    }
    void Skip()
    {
        range = 1;
    }
    void OpenTreasure()
    {
        state = 1;
        data.bd.treasureNum--;
        button_open.SetActive(false);
        button_skip.SetActive(true);
    }
}
