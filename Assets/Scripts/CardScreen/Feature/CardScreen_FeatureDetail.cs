using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardScreen_FeatureDetail : MonoBehaviour
{
    public int fid;
    public int mode;
    public TextMeshProUGUI content;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        Description();
    }

    void Description()
    {
        content.text = "";
    }
}
