using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Market_DrawCard : MonoBehaviour
{
    public int pid;
    public int cid;
    public GameObject anim;
    public GameObject cover;
    public GameObject card;
    public GameObject button_yes;
    public GameObject button_no;
    public GameObject button_skip;
    public Market_Info data;
    IUF uf = new UIFunctions();
    public float range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button_yes.GetComponent<Button>().onClick.AddListener(Yes);
        button_no.GetComponent<Button>().onClick.AddListener(No);
        button_skip.GetComponent<Button>().onClick.AddListener(Skip);
        button_yes.SetActive(false);
        button_no.SetActive(false);
        card.GetComponent<Market_CardDisplay>().cid= cid;
        card.SetActive(true);
        cover.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Cover/CardPool", pid);
        cover.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        range += Time.deltaTime * 0.3f;
        if (range<0.2f)
        {
            uf.EraseTexture(cover, range);
        }
        else if (range < 0.6f)
        {          
            uf.EraseTexture(cover, range);
            button_yes.SetActive(true);
            button_no.SetActive(true);
            button_skip.SetActive(false);
        }
        else
        {
            button_yes.SetActive(true);
            button_no.SetActive(true);
            button_skip.SetActive(false);
            anim.SetActive(false);          
        }
    }
    void Yes()
    {
        data.bd.cardList_Total.Add(cid);
        data.bd.cardList_Weapon.Add(cid);
        data.bd.cardList_Item.Add(cid);
        data.bd.cardList_Scroll.Add(cid);
        Destroy(this.gameObject);
    }
    void No()
    {
        Destroy(this.gameObject);
    }
    void Skip()
    {
        range = 1;
    }
}
