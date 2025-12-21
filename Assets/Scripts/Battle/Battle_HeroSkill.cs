using UnityEngine;
using UnityEngine.UI;

public class Battle_HeroSkill : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public int index;
    public int kind;
    public int cid;
    public GameObject card;
    Battle_Info data;
    public float cd;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        player = data.bd.player;
        if (kind == 0)
        {
            card.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("PlayerWeapon", cid);
        }
        else if (kind == 1) 
        {
            card.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        }
        cd = player.GetComponent<Battle_Player>().weapon_cd[index];
        card.GetComponent<RectMask2D>().padding = new Vector4(0, 0, 0, cd * card.GetComponent<RectTransform>().rect.height);
    }

    // Update is called once per frame
    void Update()
    {
        cd = player.GetComponent<Battle_Player>().weapon_cd[index];
        card.GetComponent<RectMask2D>().padding = new Vector4(0, 0, 0, cd * card.GetComponent<RectTransform>().rect.height);
    }
}
