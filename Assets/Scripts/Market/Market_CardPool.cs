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
    public GameObject button_buy;
    //public GameObject tip_sellout;
    public GameObject drawCardPage;
    public Market_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button_buy.GetComponent<Button>().onClick.AddListener(Buy);
    }
    void Buy()
    {
        if (data.bd.gold >= cost)
        {
            cost-=data.bd.gold;
            GameObject p = GameObject.Instantiate(drawCardPage, canvas.transform);
            p.GetComponent<Market_DrawCard>().cid = 0;///////////////////////////////
            p.SetActive(true);
        }
    }
}
