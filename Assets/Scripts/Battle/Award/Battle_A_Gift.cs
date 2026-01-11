using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Battle_A_Gift : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public int gid;
    public GameObject page;
    public GameObject icon;
    public TextMeshProUGUI text_name;
    public TextMeshProUGUI text_description;
    public GameObject button_gain;
    public Battle_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        button_gain.GetComponent<Button>().onClick.AddListener(GainGift);
        text_name.text = data.d_skill.skillDesList[gid].skill_name;
        text_description.text = Content();
        //text_description.text = data.d_skill.skillDesList[gid].skill_description;
        icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("HeroGift", gid);
    }
    string Content()
    {
        string text = "";
        if (data.skills.skills[gid].mana > 0)
        {
            text += "最大能量+" + data.skills.skills[gid].mana + "\n";
        }
        if (data.skills.skills[gid].blood > 0)
        {
            text += "最大生命+"+ data.skills.skills[gid].blood+"\n";
        }     
        if (data.skills.skills[gid].speed > 0)
        {
            text += "移动速度+" + (int)(data.skills.skills[gid].speed*100) + "\n";
        }
        if (data.skills.skills[gid].atkspeed > 0)
        {
            text += "攻击速度+" + (int)(data.skills.skills[gid].atkspeed*100) + "%\n";
        }
        if (data.skills.skills[gid].phurt > 0)
        {
            text += "物理攻击+" + data.skills.skills[gid].phurt + "\n";
        }
        if (data.skills.skills[gid].mhurt > 0)
        {
            text += "法术攻击+" + data.skills.skills[gid].mhurt + "\n";
        }
        if (data.skills.skills[gid].trans > 0)
        {
            text += "破甲+" + data.skills.skills[gid].trans + "\n";
        }
        if (data.skills.skills[gid].defence > 0)
        {
            text += "护甲+" + data.skills.skills[gid].defence + "\n";
        }
        if (data.skills.skills[gid].critical > 0)
        {
            text += "暴击率+" + (int)(data.skills.skills[gid].critical*100) + "%\n";
        }
        if (data.skills.skills[gid].repel > 0)
        {
            text += "减速+" + (int)(data.skills.skills[gid].repel) + "%\n";
        }
        if (data.skills.skills[gid].dodge > 0)
        {
            text += "闪避+" + (int)(data.skills.skills[gid].dodge*100) + "%\n";
        }
        if (data.skills.skills[gid].extraexp > 0)
        {
            text += "额外经验+" + data.skills.skills[gid].extraexp + "\n";
        }
        if (data.skills.skills[gid].extramoney > 0)
        {
            text += "额外金币+" + data.skills.skills[gid].extramoney + "\n";
        }
        if (data.skills.skills[gid].extrahurt > 0)
        {
            text += "额外伤害+" + (int)(data.skills.skills[gid].extrahurt*100) + "%\n";
        }
        return text;
    }

    void GainGift()
    {
        data.bd.SkillList.Add(gid);
        if (data.bd.awardNum > 1)
        {
            data.bd.awardNum--;
            data.page_state = 0;
        }
        else
        {
            data.bd.awardNum--;
            data.page_state = 0;
            data.settlement = 3;
        }
        data.ComputeHeroFeature();
        Destroy(page);
    }
}
