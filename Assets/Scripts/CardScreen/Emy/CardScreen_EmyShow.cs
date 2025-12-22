using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardScreen_EmyShow : MonoBehaviour
{
    public List<GameObject> template;
    public List<GameObject> display_list = new List<GameObject>();
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
        for(int i = 0; i < template.Count; i++)
        {
            if(i < data.cardScreen.emylist.Count)
            {
                GameObject e = GameObject.Instantiate(emycard, emycard.transform.parent);
                e.transform.position = template[i].transform.position;
                e.GetComponent<CardScreen_EmyCard>().eid = data.cardScreen.emylist[i];
                display_list.Add(e);
                e.SetActive(true);
            }
        }
    }
}
