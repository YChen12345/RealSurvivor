using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Battle_BattleDataDisplay : MonoBehaviour
{
    IUF uf = new Functions();
    public Battle_Info data;
    public GameObject blood_line;
    public TextMeshProUGUI blood_value;
    public GameObject defence_line;
    public TextMeshProUGUI defence_value;
    public GameObject exp_line;
    public TextMeshProUGUI exp_value;
    public GameObject tip_treasure;
    public GameObject tip_levelUp;
    public TextMeshProUGUI treasureNum;
    public TextMeshProUGUI LevelUpTimes;
    public TextMeshProUGUI waveNum;
    public TextMeshProUGUI countBack;
    public TextMeshProUGUI heroGold;
    public TextMeshProUGUI heroLev;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        player = data.bd.player;
    }

    // Update is called once per frame
    void Update()
    {
        Display();
    }
    void Display()
    {
        blood_line.GetComponent <Slider>().value = 
            (float)player.GetComponent<Battle_Player>().hd_.blood/(float)player.GetComponent<Battle_Player>().hd.blood;
        defence_line.GetComponent<Slider>().value =
           (float)player.GetComponent<Battle_Player>().hd_.defence / (float)player.GetComponent<Battle_Player>().hd.defence;
        exp_line.GetComponent<Slider>().value = (float)data.bd.exp/(float)(data.bd.heroLev * 10);
        blood_value.text 
            = "血量:"+player.GetComponent<Battle_Player>().hd_.blood + "/" + player.GetComponent<Battle_Player>().hd.blood;
        defence_value.text
            = "护甲:" + player.GetComponent<Battle_Player>().hd_.defence + "/" + player.GetComponent<Battle_Player>().hd.defence;
        exp_value.text
            = "经验:"+data.bd.exp + "/" + data.bd.heroLev*10;
        treasureNum.text = "" +data.bd.treasureNum;
        LevelUpTimes.text = "" + data.bd.awardNum;
        if (data.bd.treasureNum > 0)
        {
            tip_treasure.SetActive(true);
        }
        else
        {
            tip_treasure.SetActive(false);
        }
        if (data.bd.awardNum > 0)
        {
            tip_levelUp.SetActive(true);
        }
        else
        {
            tip_levelUp.SetActive(false);
        }
        waveNum.text = "第" + (data.bd.wave+1)+"波";
        countBack.text = "" +(int)(data.clock - data.totaltime);
        heroGold.text = "金币:" + data.bd.gold;
        heroLev.text = "LV" + data.bd.heroLev;
    }
}
