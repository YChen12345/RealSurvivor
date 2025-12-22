using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardScreen_EmyDetail : MonoBehaviour
{
    public int eid;
    Enemy enemy;
    public GameObject page;
    public GameObject emy_avatar;
    public GameObject button_close;
    public TextMeshProUGUI text_name;
    public TextMeshProUGUI text_enemyLV;
    public TextMeshProUGUI text_description;
    public TextMeshProUGUI blood;
    public TextMeshProUGUI defence;
    public TextMeshProUGUI hurt;
    public TextMeshProUGUI trans;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI atkgap;
    public TextMeshProUGUI atkdistance;
    public CardScreen_Info data;
    IUF uf = new UIFunctions();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        enemy.Init();
        text_name.text = "";
        text_enemyLV.text = "";
        text_description.text = "";
        blood.text = "生命："+enemy.blood;
        defence.text = "护甲：" + enemy.defence;
        hurt.text = "伤害：" + enemy.attack;
        trans.text = "破甲：" + enemy.trans;
        speed.text = "移动速度：" + enemy.speed;
        atkgap.text = "攻击间隔：" + enemy.atkgap;
        atkdistance.text = "攻击距离：" + enemy.atkdistance;
        emy_avatar.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("EmyCard/Emy", eid);
        button_close.GetComponent<Button>().onClick.AddListener(Close);

    }
    // Update is called once per frame
    void Close()
    {
        Destroy(page);
    }
}
