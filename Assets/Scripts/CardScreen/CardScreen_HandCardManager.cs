using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CardScreen_HandCardManager : MonoBehaviour
{
    public List<GameObject> template;
    public List<GameObject> display_list = new List<GameObject>();
    public GameObject handcard;
    public CardScreen_Info data;
    IUF uf = new UIFunctions();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        SetHandCard();
    }

    // Update is called once per frame
    public void SetHandCard()
    {
        for (int i = 0; i < display_list.Count; i++)
        {
            if (display_list[i] != null)
            {
                Destroy(display_list[i]);
            }
        }
        display_list.Clear();
        data.cardScreen.handCard.Clear();
        for (int i = 0; i < template.Count; i++)
        {
            int cid = 0;
            GameObject c = GameObject.Instantiate(handcard, handcard.transform.parent);
            c.transform.position = template[i].transform.position;
            c.GetComponent<CardScreen_HandCard>().index = i;
            c.GetComponent<CardScreen_HandCard>().cid = cid;
            data.cardScreen.handCard.Add(cid);
            display_list.Add(c);
            c.SetActive(true);
        }
    }
}
