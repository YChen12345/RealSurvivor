using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CardScreen_RemainCard : MonoBehaviour
{
    public int state;
    public int current_state;
    public GameObject card;
    public List<GameObject> template;
    public List<GameObject> displayList;
    public CardScreen_Info data;
    public int pageNum;
    public int currentPage;
    public List<int> cards;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        cards = new List<int>(data.cardScreen.remainCard);
        DisplayAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPage != pageNum || current_state != state)
        {
            currentPage = pageNum;
            cards = new List<int>(data.bd.cardList_Total);
            current_state = state;
            switch (state)
            {
                case 0:
                    DisplayAll();
                    break;
                case 1:
                    DisplayWeapon();
                    break;
                case 2:
                    DisplayItem();
                    break;
                case 3:
                    DisplayScroll();
                    break;
            }
        }
    }
    void DisplayAll()
    {
        for (int i = 0; i < displayList.Count; i++)
        {
            if (displayList[i] != null)
            {
                Destroy(displayList[i]);
            }
        }
        displayList.Clear();
        for (int i = 0; i < template.Count; i++)
        {
            int index = pageNum * template.Count + i;
            if (index < data.cardScreen.remainCard.Count)
            {
                GameObject c = GameObject.Instantiate(card, card.transform.parent);
                c.transform.position = template[i].transform.position;
                c.GetComponent<Market_Card>().cid = data.cardScreen.remainCard[index];
                displayList.Add(c);
                c.SetActive(true);
            }
            else
            {
                break;
            }
        }
    }
    void DisplayWeapon()
    {
        for (int i = 0; i < displayList.Count; i++)
        {
            if (displayList[i] != null)
            {
                Destroy(displayList[i]);
            }
        }
        displayList.Clear();
        for (int i = 0; i < template.Count; i++)
        {
            int index = pageNum * template.Count + i;
            if (index < data.cardScreen.remainCard_weapon.Count)
            {
                GameObject c = GameObject.Instantiate(card, card.transform.parent);
                c.transform.position = template[i].transform.position;
                c.GetComponent<Market_Card>().cid = data.cardScreen.remainCard_weapon[index];
                displayList.Add(c);
                c.SetActive(true);
            }
            else
            {
                break;
            }
        }
    }
    void DisplayItem()
    {
        for (int i = 0; i < displayList.Count; i++)
        {
            if (displayList[i] != null)
            {
                Destroy(displayList[i]);
            }
        }
        displayList.Clear();
        for (int i = 0; i < template.Count; i++)
        {
            int index = pageNum * template.Count + i;
            if (index < data.cardScreen.remainCard_item.Count)
            {
                GameObject c = GameObject.Instantiate(card, card.transform.parent);
                c.transform.position = template[i].transform.position;
                c.GetComponent<Market_Card>().cid = data.cardScreen.remainCard_item[index];
                displayList.Add(c);
                c.SetActive(true);
            }
            else
            {
                break;
            }
        }
    }
    void DisplayScroll()
    {
        for (int i = 0; i < displayList.Count; i++)
        {
            if (displayList[i] != null)
            {
                Destroy(displayList[i]);
            }
        }
        displayList.Clear();
        for (int i = 0; i < template.Count; i++)
        {
            int index = pageNum * template.Count + i;
            if (index < data.cardScreen.remainCard_scroll.Count)
            {
                GameObject c = GameObject.Instantiate(card, card.transform.parent);
                c.transform.position = template[i].transform.position;
                c.GetComponent<Market_Card>().cid = data.cardScreen.remainCard_scroll[index];
                displayList.Add(c);
                c.SetActive(true);
            }
            else
            {
                break;
            }
        }
    }
}
