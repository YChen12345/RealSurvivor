using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CardScreen_RemainCard_NextPage : MonoBehaviour
{
    public GameObject button;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        button.GetComponent<Button>().onClick.AddListener(LastPage);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CardScreen_RemainCard>().pageNum * GetComponent<CardScreen_RemainCard>().template.Count
            >= data.cardScreen.remainCard.Count - GetComponent<CardScreen_RemainCard>().template.Count)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }
    void LastPage()
    {
        GetComponent<CardScreen_RemainCard>().pageNum++;
    }
}
