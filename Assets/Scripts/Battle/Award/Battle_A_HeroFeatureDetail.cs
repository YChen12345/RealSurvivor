using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Battle_A_HeroFeatureDetail : MonoBehaviour
{
    public int fid;
    public int mode;
    public TextMeshProUGUI content;
    public Battle_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        Description();
    }

    void Description()
    {
        if (mode == 0)
        {
            switch (fid)
            {
                case 0:
                    content.text = "拥有的金币数量";
                    break;
                case 1:
                    content.text = "当前角色的能量，使用卡牌会消耗能量";
                    break;
            }
        }
        if (mode == 1)
        {
            switch (fid) 
            {
                case 0:
                    content.text = "角色的等级";
                    break;
                case 1:
                    content.text = "角色最大生命值";
                    break;
                case 2:
                    content.text = "角色的移动速度";
                    break;
                case 3:
                    content.text = "角色的护甲值，护甲值为0后会受到双倍伤害";
                    break;
                case 4:
                    content.text = "角色的攻击速度";
                    break;
                case 5:
                    content.text = "角色的物理攻击";
                    break;
                case 6:
                    content.text = "角色的法术攻击";
                    break;
                case 7:
                    content.text = "破甲用于击破敌人护甲，对护甲为0的敌人会造成双倍伤害";
                    break;
                case 8:
                    content.text = "攻击造成暴击的概率，暴击会造成对生命的双倍伤害";
                    break;
                case 9:
                    content.text = "有概率闪避攻击(上限为90%)";
                    break;
                case 10:
                    content.text = "下一回合结束后获得额外金币数";
                    break;
                case 11:
                    content.text = "下一回合结束后获得额外经验数";
                    break;
                case 12:
                    content.text = "攻击对敌人的减速效果，减速上限为90%";
                    break;
                case 13:
                    content.text = "攻击对敌人护甲和生命造成的额外伤害";
                    break;
                case 14:
                    content.text = "下一回合角色的能量";
                    break;
            }
        }
        int multi = (content.text.Length / 18);
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().sizeDelta.y * (multi * 0.5f + 1));
    }
}
