using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponChoose_Hero : MonoBehaviour
{
    public int heroID;
    public TextMeshProUGUI hero_name;
    public TextMeshProUGUI hero_content;
    GameObject image;
    IUF uf;
    IAnim anim = new UIAnimationPlayer();
    public WeaponChoose_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("WeaponChoose").GetComponent<WeaponChoose_Info>();
        heroID = data.bd.heroID;
        image = this.gameObject;
        image.GetComponent<Image>().sprite= uf.LoadResource<Sprite>("HeroCard", heroID);
        anim.SetFrameTime(0.1f);
        anim.SetSprites("HeroCardAnim/" + heroID);
        Config_D_hero d_hero = uf.LoadStructFromJson<Config_D_hero>("Config/D/Config_D_hero");
        hero_name.text = d_hero.heroDesList[heroID].hero_name;
        hero_content.text = Content();
    }
    private void Update()
    {
        anim.AnimPlay(this.gameObject, 0, Time.deltaTime);
    }
    string Content()
    {
        Config_D_hero d_hero = uf.LoadStructFromJson<Config_D_hero>("Config/D/Config_D_hero");
        Config_Hero h = uf.LoadStructFromJson<Config_Hero>("Config/Config_Hero");
        HeroData hd = h.heros[heroID];
        string text = "";
        text+= "<b>" + d_hero.heroDesList[heroID].hero_name + "</b>\n";
        if (hd.blood > 0)
        {
            text += "基础生命：" + hd.blood + "\n";
        }
        if (hd.defence > 0)
        {
            text += "基础护甲：" + hd.defence + "\n";
        }
        if (hd.mana > 0)
        {
            text += "基础能量：" + hd.mana + "\n";
        }
        if (hd.speed > 0)
        {
            text += "基础移速：" + (int)(hd.speed * 100) + "\n";
        }
        if (hd.trans > 0)
        {
            text += "基础破甲：" + hd.trans + "\n";
        }
        if (hd.atkspeed > 0)
        {
            text += "基础攻速：" + (int)(hd.atkspeed * 100) + "%\n";
        }
        if (hd.phurt > 0)
        {
            text += "基础物攻：" + hd.phurt + "\n";
        }
        if (hd.mhurt > 0)
        {
            text += "基础法攻：" + hd.mhurt + "\n";
        }
        if (hd.critical > 0)
        {
            text += "基础暴击率：" + (int)(hd.critical * 100) + "%\n";
        }
        if (hd.repel > 0)
        {
            text += "基础减速：" + (int)(hd.repel) + "%\n";
        }
        if (hd.dodge > 0)
        {
            text += "闪避：" + (int)(hd.dodge * 100) + "%\n";
        }
        if (hd.extraexp > 0)
        {
            text += "额外经验：" + hd.extraexp + "\n";
        }
        if (hd.extramoney > 0)
        {
            text += "额外金币：" + hd.extramoney + "\n";
        }
        if (hd.extrahurt > 0)
        {
            text += "额外伤害：" + (int)(hd.extrahurt * 100) + "%\n";
        }
        return text;
    }
}
