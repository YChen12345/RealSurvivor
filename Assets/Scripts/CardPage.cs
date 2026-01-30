using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardPage : MonoBehaviour
{
    public int cid;
    public Config_Card cards;
    public Config_D_card d_card;
    public TextMeshProUGUI front_card_name;
    public TextMeshProUGUI front_card_cost;
    public TextMeshProUGUI front_card_category;
    public TextMeshProUGUI back_card_name;
    public TextMeshProUGUI back_card_rare;
    public TextMeshProUGUI back_card_content;
    public TextMeshProUGUI back_card_cost;
    public TextMeshProUGUI back_card_category;
   
    public void ShowMessage()
    {
        front_card_name.text = d_card.cardDesList[cid].card_name;
        front_card_cost.text = ""+cards.cards[cid].cost;
        switch (cards.cards[cid].kind)
        {
            case 0:
                front_card_category.text = "武器";
                back_card_category.text = "类别：武器牌";
                break;
            case 1:
                front_card_category.text = "道具";
                back_card_category.text = "类别：道具牌";
                break;
            case 2:
                front_card_category.text = "卷轴";
                back_card_category.text = "类别：卷轴牌";
                break;
        }
        back_card_name.text = "名称："+ d_card.cardDesList[cid].card_name;
        switch (cards.cards[cid].rare)
        {
            case 0:
                back_card_rare.text = "稀有度：" + "<color=#606060>普通</color>";
                break;
            case 1:
                back_card_rare.text = "稀有度：" + "<color=#4682B4>稀有</color>";
                break;
            case 2:
                back_card_rare.text = "稀有度：" + "<color=#FF00FF>史诗</color>";
                break;
            case 3:
                back_card_rare.text = "稀有度：" + "<color=#FFD700>传说</color>";
                break;
            case 4:
                back_card_rare.text = "稀有度：" + "<color=#FF0000>神话</color>";
                break;
        }     
        back_card_cost.text = "使用消耗：" + cards.cards[cid].cost+"能量";
        back_card_content.text = CardDescription();
        //back_card_content.text = d_card.cardDesList[cid].card_description;
    }
    string CardDescription()
    {
        string content = "";
        if (cards.cards[cid].kind == 0)
        {
            content += "武器效果：\n";
            int hurt_i = 0;
            string hurt_text="";
            if (cards.cards[cid].weapon.basichurt > 0)
            {
                hurt_text += "伤害：" + cards.cards[cid].weapon.basichurt;
            }
          
            if (cards.cards[cid].weapon.hurt_p > 0)
            {
                hurt_text += "<color=#FF0000>+" + cards.cards[cid].weapon.hurt_p+ "*物攻</color>";
                hurt_i++;
            }
            if (cards.cards[cid].weapon.hurt_m > 0)
            {
                hurt_text += "<color=#00008B>+" + cards.cards[cid].weapon.hurt_m + "*法攻</color>";
                hurt_i++;
            }
            if (hurt_i > 1)
            {
                hurt_text = "<size=28>"+hurt_text+"</size>";
            }
            content += hurt_text;
            content += "\n";
            if (cards.cards[cid].weapon.basictrans > 0)
            {
                content += "破甲：" + cards.cards[cid].weapon.basictrans;
                if (cards.cards[cid].weapon.trans_t > 0)
                {
                    content += "+" + cards.cards[cid].weapon.trans_t + "*破甲";
                }
            }
            else
            {
                if (cards.cards[cid].weapon.trans_t > 0)
                {
                    content += cards.cards[cid].weapon.trans_t + "*破甲";
                }
                else
                {
                    content += "破甲：无破甲效果";
                }           
            }
            content += "\n";
            content += "基础攻击间隔：" + cards.cards[cid].weapon.atkgap + "秒";
            content += "\n";
            content += "攻击距离：" + cards.cards[cid].weapon.triggerdistance + "";
            content += "\n";
            switch (cards.cards[cid].weapon.mode)
            {
                case 0:
                    content += "攻击模式：" + "普通";
                    break;
                case 1:
                    content += "攻击模式：" + "散射";
                    break;
                case 2:
                    content += "攻击模式：" + "高级散射";
                    break;
                case 3:
                    content += "攻击模式：" + "弹幕";
                    break;
                case 4:
                    content += "攻击模式：" + "高级弹幕";
                    break;
                case 5:
                    content += "攻击模式：" + "究极弹幕";
                    break;
            }
            content += "\n";
            if (cards.cards[cid].weapon.repel > 0)
            {
                content += "基础减速：" + (int)cards.cards[cid].weapon.repel + "%";
            }
            else
            {
                content += "基础减速：" + "0";
            }
            content += "\n";
            if (cards.cards[cid].weapon.maxcross > 0)
            {
                content += "攻击至多可穿透" + cards.cards[cid].weapon.maxcross+"个敌人";
                content = "<size=32>" + content + "</size>";
            }
        }
        if (cards.cards[cid].kind == 1)
        {
            content += "道具效果：\n";
            if (cards.cards[cid].item.blood > 0)
            {
                content += "生命+" + cards.cards[cid].item.blood+"";
                content += "\n";
            }
            if (cards.cards[cid].item.defence > 0)
            {
                content += "护甲+" + cards.cards[cid].item.defence + "";
                content += "\n";
            }
            if (cards.cards[cid].item.speed > 0)
            {
                content += "移动速度+" + cards.cards[cid].item.speed*100 + "";
                content += "\n";
            }
            if (cards.cards[cid].item.atkspeed > 0)
            {
                content += "攻击速度+" + (int)(cards.cards[cid].item.atkspeed*100) + "%";
                content += "\n";
            }
            if (cards.cards[cid].item.phurt > 0)
            {
                content += "物理攻击+" + cards.cards[cid].item.phurt + "";
                content += "\n";
            }
            if (cards.cards[cid].item.mhurt > 0)
            {
                content += "法术攻击+" + cards.cards[cid].item.mhurt + "";
                content += "\n";
            }
            if (cards.cards[cid].item.trans > 0)
            {
                content += "破甲+" + cards.cards[cid].item.trans + "";
                content += "\n";
            }
            if (cards.cards[cid].item.extrahurt > 0)
            {
                content += "额外伤害+" + (int)(cards.cards[cid].item.extrahurt*100) + "%";
                content += "\n";
            }
            if (cards.cards[cid].item.critical > 0)
            {
                content += "暴击率+" + (int)(cards.cards[cid].item.critical*100) + "%";
                content += "\n";
            }
            if (cards.cards[cid].item.dodge > 0)
            {
                content += "闪避+" + (int)(cards.cards[cid].item.dodge * 100) + "%";
                content += "\n";
            }
            if (cards.cards[cid].item.repel > 0)
            {
                content += "减速+" + cards.cards[cid].item.repel + "%";
                content += "\n";
            }
            if (cards.cards[cid].item.extraexp > 0)
            {
                content += "额外经验+" + cards.cards[cid].item.extraexp + "";
                content += "\n";
            }
            if (cards.cards[cid].item.extramoney > 0)
            {
                content += "额外金币+" + cards.cards[cid].item.extramoney + "";
                content += "\n";
            }
            if (cards.cards[cid].item.mana > 0)
            {
                content += "下轮能量+" + cards.cards[cid].item.mana + "";
                content += "\n";
            }
        }
        if (cards.cards[cid].kind == 2)
        {
            content += "卷轴效果：\n";
            if (cards.cards[cid].scroll.blood > 0)
            {
                content += "生命+" + cards.cards[cid].scroll.blood + "";
                content += "\n";
            }
            if (cards.cards[cid].scroll.defence > 0)
            {
                content += "护甲+" + cards.cards[cid].scroll.defence + "";
                content += "\n";
            }
            if (cards.cards[cid].scroll.speed > 0)
            {
                content += "移动速度+" + cards.cards[cid].scroll.speed*100 + "";
                content += "\n";
            }
            if (cards.cards[cid].scroll.atkspeed > 0)
            {
                content += "攻击速度+" + (int)(cards.cards[cid].scroll.atkspeed*100) + "%";
                content += "\n";
            }
            if (cards.cards[cid].scroll.phurt > 0)
            {
                content += "物理攻击+" + cards.cards[cid].scroll.phurt + "";
                content += "\n";
            }
            if (cards.cards[cid].scroll.mhurt > 0)
            {
                content += "法术攻击+" + cards.cards[cid].scroll.mhurt + "";
                content += "\n";
            }
            if (cards.cards[cid].scroll.trans > 0)
            {
                content += "破甲+" + cards.cards[cid].scroll.trans + "";
                content += "\n";
            }
            if (cards.cards[cid].scroll.extrahurt > 0)
            {
                content += "额外伤害+" + (int)(cards.cards[cid].scroll.extrahurt*100) + "%";
                content += "\n";
            }
            if (cards.cards[cid].scroll.critical > 0)
            {
                content += "暴击率+" + (int)(cards.cards[cid].scroll.critical*100) + "%";
                content += "\n";
            }         
            if (cards.cards[cid].scroll.dodge > 0)
            {
                content += "闪避+" + (int)(cards.cards[cid].scroll.dodge*100) + "%";
                content += "\n";
            }         
            if (cards.cards[cid].scroll.repel > 0)
            {
                content += "减速+" + cards.cards[cid].scroll.repel + "%";
                content += "\n";
            }         
            if (cards.cards[cid].scroll.extraexp > 0)
            {
                content += "额外经验+" + cards.cards[cid].scroll.extraexp + "";
                content += "\n";
            }          
            if (cards.cards[cid].scroll.extramoney > 0)
            {
                content += "额外金币+" + cards.cards[cid].scroll.extramoney + "";
                content += "\n";
            }
            if (cards.cards[cid].scroll.mana > 0)
            {
                content += "下轮能量+" + cards.cards[cid].scroll.mana + "";
                content += "\n";
            }
        }
        return content;
    }
}
