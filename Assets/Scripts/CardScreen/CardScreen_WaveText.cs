using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardScreen_WaveText : MonoBehaviour
{
    public TextMeshProUGUI text_wave;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        text_wave.text = "第" + (data.bd.wave+1) + "波";
    }
}
