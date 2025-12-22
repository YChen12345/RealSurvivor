using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardScreen_HeroFeature : MonoBehaviour
{
    public int fid;
    public int mode;
    public GameObject icon;
    public GameObject detail;
    public TextMeshProUGUI feature_name;
    public TextMeshProUGUI feature_value;
    public CardScreen_Info data;
    IUF uf = new UIFunctions();

    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        Init();
        detail.GetComponent<CardScreen_FeatureDetail>().mode = mode;
        detail.GetComponent<CardScreen_FeatureDetail>().fid = fid;
    }

    // Update is called once per frame
    void Update()
    {
        Refresh();
    }
    void Init()
    {
        if (mode == 0)
        {
            icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("HeroFeature_H", fid);
            switch (fid)
            {
                case 0:

                    feature_name.text = "金币";
                    feature_value.text = "" + data.bd.gold;
                    break;
                case 1:
                    feature_name.text = "能量";
                    feature_value.text = "" + data.hd.mana;
                    break;
            }
        }
        else if (mode == 1)
        {
            icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("HeroFeature_V", fid);
            switch (fid)
            {
                case 0:
                    feature_name.text = "生命";
                    feature_value.text = "" + data.hd.blood;
                    break;
                case 1:
                    feature_name.text = "速度";
                    feature_value.text = "" + data.hd.speed;
                    break;
                case 2:
                    feature_name.text = "护甲";
                    feature_value.text = "" + data.hd.defence;
                    break;
                case 3:
                    feature_name.text = "攻击速度";
                    feature_value.text = "" + (int)(data.hd.atkspeed * 100) + "%";
                    break;
                case 4:
                    feature_name.text = "物理攻击";
                    feature_value.text = "" + data.hd.phurt;
                    break;
                case 5:
                    feature_name.text = "法术攻击";
                    feature_value.text = "" + data.hd.mhurt;
                    break;
                case 6:
                    feature_name.text = "破甲";
                    feature_value.text = "" + data.hd.trans;
                    break;
                case 7:
                    feature_name.text = "暴击率";
                    feature_value.text = "" + (int)(data.hd.critical * 100) + "%";
                    break;
                case 8:
                    feature_name.text = "闪避";
                    feature_value.text = "" + (int)(data.hd.dodge * 100) + "%";
                    break;
                case 9:
                    feature_name.text = "额外金币";
                    feature_value.text = "" + data.hd.extramoney;
                    break;
                case 10:
                    feature_name.text = "额外经验";
                    feature_value.text = "" + data.hd.extraexp;
                    break;
                case 11:
                    feature_name.text = "击退";
                    feature_value.text = "" + data.hd.repel;
                    break;
                case 12:
                    feature_name.text = "额外伤害";
                    feature_value.text = "" + (int)(data.hd.extrahurt * 100) + "%";
                    break;
            }
        }
    }
    void Refresh()
    {
        if (mode == 0)
        {
            switch (fid)
            {
                case 0:
                    feature_value.text = "" + data.bd.gold;
                    break;
                case 1:
                    feature_value.text = "" + data.hd.mana;
                    break;
            }
        }
        else if (mode == 1)
        {
            switch (fid)
            {
                case 0:
                    feature_value.text = "" + data.hd.blood;
                    break;
                case 1:
                    feature_value.text = "" + data.hd.speed;
                    break;
                case 2:
                    feature_value.text = "" + data.hd.defence;
                    break;
                case 3:
                    feature_value.text = "" + (int)(data.hd.atkspeed * 100) + "%";
                    break;
                case 4:
                    feature_value.text = "" + data.hd.phurt;
                    break;
                case 5:
                    feature_value.text = "" + data.hd.mhurt;
                    break;
                case 6:
                    feature_value.text = "" + data.hd.trans;
                    break;
                case 7:
                    feature_value.text = "" + (int)(data.hd.critical * 100) + "%";
                    break;
                case 8:
                    feature_value.text = "" + (int)(data.hd.dodge * 100) + "%";
                    break;
                case 9:
                    feature_value.text = "" + data.hd.extramoney;
                    break;
                case 10:
                    feature_value.text = "" + data.hd.extraexp;
                    break;
                case 11:
                    feature_value.text = "" + data.hd.repel;
                    break;
                case 12:
                    feature_value.text = "" + (int)(data.hd.extrahurt * 100) + "%";
                    break;
            }
        }
    }
}
