using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardScreen_BossShow : MonoBehaviour
{
    public GameObject template;
    public GameObject display;
    public GameObject emycard;
    public CardScreen_Info data;
    IUF uf = new UIFunctions();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        ShowEmyCard();
    }

    // Update is called once per frame
    void ShowEmyCard()
    {
        if (data.cardScreen.boss >= 0)
        {
            GameObject e = GameObject.Instantiate(emycard, emycard.transform.parent);
            e.transform.position = template.transform.position;
            e.GetComponent<CardScreen_EmyCard>().eid = data.cardScreen.boss;
            display = e;
            e.SetActive(true);
        }    
    }
}
