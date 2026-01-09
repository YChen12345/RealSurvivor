using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_CardPoolDetail : MonoBehaviour
{
    public int pid;
    public TextMeshProUGUI text_content;
    public Market_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        Content();
    }
    void Content()
    {
        string text = "";
        MarketPossiblity mp = data.cardpools.possiblity[pid];
        text += "<b>"+data.d_cardpool.cardPoolDesList[pid].cardpool_name+"</b>";
        text += "\n";
        text += "抽卡概率：\n";
        text += "普通：" + (int)(mp.possiblity_rare[0] * 100) +"%\n";
        text += "稀有：" + (int)(mp.possiblity_rare[1] * 100) + "%\n";
        text += "史诗：" + (int)(mp.possiblity_rare[2] * 100) + "%\n";
        text += "传说：" + (int)(mp.possiblity_rare[3] * 100) + "%\n";
        text += "神话：" + (int)(mp.possiblity_rare[4] * 100) + "%\n";
        text_content.text = text;
    }
}
