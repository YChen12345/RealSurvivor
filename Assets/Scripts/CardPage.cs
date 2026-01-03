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
                back_card_rare.text = "稀有度：" + "<color=#FFFFFF>普通</color>";
                break;
            case 1:
                back_card_rare.text = "稀有度：" + "<color=#00FFFF>稀有</color>";
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
        back_card_content.text = d_card.cardDesList[cid].card_description;
    }
}
