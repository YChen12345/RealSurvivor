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
        text_name.text = "";
        text_description.text = "";
        icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("HeroGift", gid);
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
        Destroy(page);
    }
}
