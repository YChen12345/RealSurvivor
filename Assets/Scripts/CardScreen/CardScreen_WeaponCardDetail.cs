using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.GPUSort;
public class CardScreen_WeaponCardDetail : MonoBehaviour
{
    public int weaponID;
    IUF uf = new UIFunctions();
    public GameObject page;
    public GameObject avatar;
    public TextMeshProUGUI text_content;
    public GameObject button_close;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        avatar.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("WeaponCard", weaponID);
        button_close.GetComponent<Button>().onClick.AddListener(Close);
        text_content.text = Content();
    }
    void Close()
    {
        Destroy(page);
    }
    string Content()
    {
        Config_D_weapon d_weapon = uf.LoadStructFromJson<Config_D_weapon>("Config/D/Config_D_weapon");
        Config_Weapon w = uf.LoadStructFromJson<Config_Weapon>("Config/Config_Weapon");
        Weapon wd = w.weapons[data.bd.weaponID];
        string text = "";
        text += "<b>" + d_weapon.weaponDesList[data.bd.weaponID].weapon_name + "</b>\n";
        text += "武器效果：\n";
        if (wd.basichurt > 0)
        {
            text += "伤害：" + wd.basichurt;
        }
        if (wd.hurt_p > 0)
        {
            text += "<color=#FF0000>+" + wd.hurt_p + "*物攻</color>";
        }
        if (wd.hurt_m > 0)
        {
            text += "<color=#00FFFF>+" + wd.hurt_m + "*法攻</color>";
        }
        text += "\n";
        if (wd.basictrans > 0)
        {
            text += "破甲：" + wd.basictrans;
            if (wd.trans_t > 0)
            {
                text += "+" + wd.trans_t + "*破甲";
            }
        }
        else
        {
            text += "破甲：无破甲效果";
        }
        text += "\n";
        text += "基础攻击间隔:" + wd.atkgap + "秒";
        text += "\n";
        text += "攻击距离:" + wd.triggerdistance + "";
        text += "\n";
        switch (wd.mode)
        {
            case 0:
                text += "攻击模式:" + "普通";
                break;
            case 1:
                text += "攻击模式:" + "散射";
                break;
            case 2:
                text += "攻击模式:" + "高级散射";
                break;
            case 3:
                text += "攻击模式:" + "环形弹幕";
                break;
            case 4:
                text += "攻击模式:" + "高级环形弹幕";
                break;
            case 5:
                text += "攻击模式:" + "普通";
                break;
        }
        text += "\n";
        if (wd.repel > 0)
        {
            text += "基础减速:" + (int)wd.repel + "%";
        }
        else
        {
            text += "基础减速:" + "0";
        }
        text += "\n";
        if (wd.maxcross > 0)
        {
            text += "攻击至多可穿透" + wd.maxcross + "个敌人";
            text = "<size=18>" + text + "</size>";
        }
        return text;
    }
}
