using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardScreen_Equipped_Scroll : MonoBehaviour
{
    public GameObject card;
    public List<GameObject> template;
    public List<GameObject> displayList;
    public CardScreen_Info data;
    public List<int> cards;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        cards = new List<int>(data.bd.ScrollCardList);
        DisplayCard();
    }

    // Update is called once per frame
    void Update()
    {
        if (cards.Count != data.bd.ScrollCardList.Count)
        {
            cards = new List<int>(data.bd.ScrollCardList);
            DisplayCard();
        }
    }
    void DisplayCard()
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
            if (i < data.bd.ScrollCardList.Count)
            {
                GameObject c = GameObject.Instantiate(card, card.transform.parent);
                c.transform.position = template[i].transform.position;
                c.GetComponent<CardScreen_EquippedCard>().cid = data.bd.ScrollCardList[i];
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
