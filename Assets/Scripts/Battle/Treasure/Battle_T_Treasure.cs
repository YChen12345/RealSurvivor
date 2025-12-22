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
            data.settlement = 3;
        }
        Destroy(page);
    }
    void Discard()
    {
        data.page_state = 0;
        if (data.bd.treasureNum <= 0)
        {
            data.settlement = 3;
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
